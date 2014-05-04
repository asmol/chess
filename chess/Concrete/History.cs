using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace chess
{
    public static class History
    {
        public static string GetHistory(List<Turn> moves, int currentMove)
        {
            IFigure[,] oldField = Game.CreateStartFigures(), newField;
            SimpleTurnProcessor processor = new SimpleTurnProcessor();
            string result = "";
            for (int i = 0; i < currentMove; i++)
            {
                newField = processor.SimulateMove(oldField,moves[i].From,moves[i].To,moves[i].PawnPromotion);
                bool isEven = i%2 == 0;
                result += (isEven ? ((i/2)+1)+". " : " ")+addMove(processor,oldField,moves[i].From,moves[i].To,moves[i].PawnPromotion);
                ETeam team = oldField[moves[i].From.Y,moves[i].From.X].Team;
                if (i != 0 && !processor.IsTeamHasNonProhibitedTurn(newField,processor.EnemyTeam(team),moves[i-1].From,moves[i-1].To))
                    result += "#";
                else
                    if (processor.IsCheck(newField,team))
                        result += "+";

                if (!isEven)
                    result += "\r\n";
                oldField = (IFigure[,])newField.Clone();
            }
            return result;
        }

        private static string addMove(SimpleTurnProcessor processor, IFigure[,] field, Point2 from, Point2 to, EPawnPromotion? promotion)
        {
            string result = "";
            if (!processor.IsCastling(field[from.Y,from.X],from,to))
            {
                bool isPassant = processor.IsPassantCapture(field,from,to);
                result += addDeparture(processor,field,from,to)+addDestination(processor,field,from,to,isPassant,promotion);
                if (isPassant)
                    result += "e.p.";
            }
            else
            {
                result += "0-0";
                if (!processor.IsKingsideCastling(from.X,to.X))
                    result += "-0";
            }
            return result;
        }

        private static string addDeparture(SimpleTurnProcessor processor, IFigure[,] field, Point2 from, Point2 to)
        {
            string result = getEnumDescription((EType)Enum.Parse(typeof(EType),field[from.Y,from.X].Type.ToString()));
            if (field[from.Y,from.X].Type != EType.Pawn && field[from.Y,from.X].Type != EType.King)
            {
                ETeam team = field[from.Y,from.X].Team;
                List<Point2> figures = processor.FiguresOfType(field,field[from.Y,from.X].Type,team);
                bool fileDiffers = true, rankDiffers = true;
                int sameTypeCount = 0;
                for (int i = 0; i < figures.Count; i++)
                    if ((figures[i].X != from.X || figures[i].Y != from.Y) && processor.IsAllowedTurnLight(field,team,new Point2(figures[i].X,figures[i].Y),to))
                    {
                        if (figures[i].X == from.X)
                            fileDiffers = false;
                        if (figures[i].Y == from.Y)
                            rankDiffers = false;
                        if (!fileDiffers && !rankDiffers)
                            break;
                        sameTypeCount++;
                    }
                    if (!rankDiffers || (sameTypeCount != 0 && fileDiffers))
                        result += xToFile(from.X);
                    if (!fileDiffers)
                        result += yToRank(from.Y);
            }
            return result;
        }

        private static string addDestination(SimpleTurnProcessor processor, IFigure[,] field, Point2 from, Point2 to, bool isPassant, EPawnPromotion? promotion)
        {
            string result = "";
            if (processor.IsCapture(field,from,to) || isPassant)
            {
                if (field[from.Y,from.X].Type == EType.Pawn)
                    result += xToFile(from.X);
                        result += "x";
            }
            result += xToFile(to.X)+yToRank(to.Y);
            if (promotion != null)
                result += getEnumDescription((EType)Enum.Parse(typeof(EType),promotion.ToString()));
            return result;
        }

        private static string xToFile(int x)
        {
            return ((char)(97+x)).ToString();
        }

        private static string yToRank(int y)
        {
            return (8-y).ToString();
        }

        private static string getEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute),false);
            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}