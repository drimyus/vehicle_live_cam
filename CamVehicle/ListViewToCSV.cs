using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamVehicle
{
    class ListViewToCSV
        /// <summary> Class for managing the listView and csv writer
        /// </summary>
    {
        public ListViewToCSV()
        {

        }

        public void listView_to_csv(ListView listView, string filePath, bool includeHidden)
            /// <summary> 
            /// convert the listView object and write to a csv table
            /// </summary>
            /// <param name="listView"> source listView </param>
            /// <param name="filePath"> file path for the target CSV file </param>
            /// <param name="includeHidden"> property of csv file writer </param>
        {
            // make header string
            StringBuilder result = new StringBuilder();
            WriteCSVRow(result, listView.Columns.Count, i => includeHidden || listView.Columns[i].Width > 0, i => listView.Columns[i].Text);

            // export data rows
            foreach (ListViewItem listItem in listView.Items)
                WriteCSVRow(result, listView.Columns.Count, i => includeHidden || listView.Columns[i].Width > 0, i => listItem.SubItems[i].Text);

            File.WriteAllText(filePath, result.ToString());
        }

        private void WriteCSVRow(StringBuilder result, int itemsCount, Func<int, bool> isColumnNeeded, Func<int, string> columnValue)
            /// <summary>
            /// write to the to the csv table
            /// </summary>
            /// <param name="result"> the string builder for csv writer </param>
            /// <param name="itemsCount"> the number of rows </param>
            /// <param name="isColumnNeeded"> the flag to write or not the row </param>
            /// <param name="columnValue"> the row data of soruce log string </param>
        {
            bool isFirstTime = true;
            for (int i = 0; i < itemsCount; i++)
            {
                if (!isColumnNeeded(i))
                    continue;

                if (!isFirstTime)
                    result.Append(",");
                isFirstTime = false;

                result.Append(String.Format("\"{0}\"", columnValue(i)));
            }
            result.AppendLine();
        }
    }
}
