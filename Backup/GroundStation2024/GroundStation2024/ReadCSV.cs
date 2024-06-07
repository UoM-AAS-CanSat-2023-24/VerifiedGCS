using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundStation2024
{
    public static class ReadCSV
    {
        public static float[] ReadCsvFile(string fileName)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };

            float[] simulatedPressureTelemetry = new float[0];

            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, config))
            {
                var pressureValueList = csv.GetRecords<float>();

                foreach (var pressureValue in pressureValueList)
                {
                    simulatedPressureTelemetry = simulatedPressureTelemetry.Append(pressureValue).ToArray();
                }

                return simulatedPressureTelemetry;
            }
        }
    }
}
