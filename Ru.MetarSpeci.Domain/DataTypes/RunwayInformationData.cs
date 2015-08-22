using System;
using System.Text;
using Ru.MetarSpeci.Enums;

namespace Ru.MetarSpeci.DataTypes
{
    public class RunwayInformationData
    {
        public RunwayInformationData(string match)
        {
            if (string.IsNullOrEmpty(match))
                return;

            IsRunwayInformation = true;
            var runwayMatch = match.Replace('R', ' ').Replace('r', ' ').Replace(" ", "");

            RunwayNumber = Convert.ToInt32(runwayMatch.Substring(0, 2));

            if (runwayMatch.Length == 8)
                if (match.IndexOf("CLRD", StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    IsPollutionStopped = true;
                    GetBrakingPerformanceFromString(runwayMatch.Substring(6, 2));
                }
                else
                {
                    GetRunwaySurfaceFromChar(runwayMatch[2]);
                    GetRunwayContaminationFromChar(runwayMatch[3]);
                    GetCoatingThicknessFromString(runwayMatch.Substring(4, 2));
                    GetBrakingPerformanceFromString(runwayMatch.Substring(6, 2));
                }
            else if (match.IndexOf("CLRD", StringComparison.InvariantCultureIgnoreCase) != -1)
            {
                IsPollutionStopped = true;
                GetBrakingPerformanceFromString(runwayMatch.Substring(7, 2));
            }
            else
            {
                GetRunwaySurfaceFromChar(runwayMatch[3]);
                GetRunwayContaminationFromChar(runwayMatch[4]);
                GetCoatingThicknessFromString(runwayMatch.Substring(5, 2));
                GetBrakingPerformanceFromString(runwayMatch.Substring(7, 2));
            }
        }

        private bool IsRunwayInformation { get; }

        private int RunwayNumber { get; }

        private bool IsPollutionStopped { get; }

        private bool IsSurfaceReported { get; set; }
        private RunwaySurface RunwaySurface { get; set; }

        private bool IsContaminationReported { get; set; }

        private RunwayContamination RunwayContamination { get; set; }

        private bool IsCoatingThicknessReported { get; set; }

        private int CoatingThickness { get; set; }

        private bool IsBrakingPerformanceReported { get; set; }

        private bool IsBrakingPermormanceIsEnum { get; set; }

        private RunwayBrakingPerformance RunwayBrakingPerformance { get; set; }

        private int BrakingPerformance { get; set; }

        public string Description
        {
            get
            {
                var result = new StringBuilder();

                if (!IsRunwayInformation)
                    return result.ToString();

                switch (RunwayNumber)
                {
                    case 88:
                        result.Append("Информация для всех полос: ");
                        break;
                    case 99:
                        result.Append("Повторение предыдущей информации: ");
                        break;
                    default:
                        result.Append("На ВПП ");
                        result.Append(RunwayNumber + ": ");
                        break;
                }

                if (!IsPollutionStopped)
                {
                    if (IsSurfaceReported)
                        result.Append(RunwaySurface.GetMetarDescription() + ", ");

                    if (IsContaminationReported)
                    {
                        result.Append("степень загрязнения ВПП ");
                        result.Append(RunwayContamination.GetMetarDescription() + ", ");
                    }

                    if (IsCoatingThicknessReported)
                        if (CoatingThickness == 99)
                            result.Append("полоса не работает в связи с чисткой, ");
                        else
                        {
                            result.Append("толщина покрытия ");
                            if (CoatingThickness == 00)
                                result.Append("менее 1мм, ");
                            else
                                result.Append(CoatingThickness + "мм, ");
                        }
                }
                else
                    result.Append("загрязнения прекратились, ");

                if (!IsBrakingPerformanceReported)
                    result.Append("ВПП не работает ");
                else
                {
                    if (IsBrakingPermormanceIsEnum)
                    {
                        result.Append("эффективность торможения ");
                        result.Append(RunwayBrakingPerformance.GetMetarDescription() + " ");
                    }
                    else
                    {
                        result.Append("коэффициент сцепления ");
                        result.Append("0," + BrakingPerformance + " ");
                    }
                }

                return result.ToString();
            }
        }

        #region Helpers

        private void GetRunwaySurfaceFromChar(char surface)
        {
            if (surface == '/')
                return;

            IsSurfaceReported = true;
            switch (surface)
            {
                case '0':
                    RunwaySurface = RunwaySurface.CleanAndDry;
                    break;
                case '1':
                    RunwaySurface = RunwaySurface.Damp;
                    break;
                case '2':
                    RunwaySurface = RunwaySurface.Wet;
                    break;
                case '3':
                    RunwaySurface = RunwaySurface.FrostOrRime;
                    break;
                case '4':
                    RunwaySurface = RunwaySurface.DrySnow;
                    break;
                case '5':
                    RunwaySurface = RunwaySurface.WetSnow;
                    break;
                case '6':
                    RunwaySurface = RunwaySurface.Slob;
                    break;
                case '7':
                    RunwaySurface = RunwaySurface.Ice;
                    break;
                case '8':
                    RunwaySurface = RunwaySurface.CompactedOrRolledSnow;
                    break;
                case '9':
                    RunwaySurface = RunwaySurface.FrozenRutsOrRidges;
                    break;
            }
        }

        private void GetRunwayContaminationFromChar(char percents)
        {
            if (percents == '/')
                return;

            IsContaminationReported = true;
            switch (percents)
            {
                case '1':
                    RunwayContamination = RunwayContamination.Less10Percents;
                    break;
                case '2':
                    RunwayContamination = RunwayContamination.From11To25Percents;
                    break;
                case '5':
                    RunwayContamination = RunwayContamination.Fromt26To50Percents;
                    break;
                case '9':
                    RunwayContamination = RunwayContamination.From51To100Percents;
                    break;
            }
        }

        private void GetCoatingThicknessFromString(string thickness)
        {
            if (thickness == "//")
                return;

            IsCoatingThicknessReported = true;
            CoatingThickness = Convert.ToInt32(thickness);
        }

        private void GetBrakingPerformanceFromString(string performance)
        {
            if (performance == "//")
                return;

            IsBrakingPerformanceReported = true;
            IsBrakingPermormanceIsEnum = true;
            switch (performance)
            {
                case "91":
                    RunwayBrakingPerformance = RunwayBrakingPerformance.Poor;
                    break;
                case "92":
                    RunwayBrakingPerformance = RunwayBrakingPerformance.FromPoorToAverage;
                    break;
                case "93":
                    RunwayBrakingPerformance = RunwayBrakingPerformance.Average;
                    break;
                case "94":
                    RunwayBrakingPerformance = RunwayBrakingPerformance.FromAverageToGood;
                    break;
                case "95":
                    RunwayBrakingPerformance = RunwayBrakingPerformance.Good;
                    break;
                case "99":
                    RunwayBrakingPerformance = RunwayBrakingPerformance.UnreliableMeasurement;
                    break;
                default:
                    IsBrakingPermormanceIsEnum = false;
                    BrakingPerformance = Convert.ToInt32(performance);
                    break;
            }
        }

        #endregion
    }
}