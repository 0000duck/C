  Microsoft.Office.Interop.Excel.Application objApp;
        Microsoft.Office.Interop.Excel._Workbook objBook;
        private void button1_Click(object sender, EventArgs e)
        {
           Execl.Workbooks objBooks;
           Execl.Sheets objSheets;
           Execl._Worksheet objSheet;
           Execl.Range range;
 
            try
            {
                //Instantiate Execl and Start a new workbook;
                objApp = new Microsoft.Office.Interop.Excel.Application();
                objBooks = objApp.Workbooks;
                objBook = objBooks.Add(Missing.Value);
                objSheets = objBook.Worksheets;
                objSheet = (Execl._Worksheet)objSheets.get_Item(1);
                //Get the range where the starting cell has the address
                //m_sStartingCell and its dimensions are m_iNumRows x m_iNumCols.
                range = objSheet.get_Range("A1", Missing.Value);
                range = range.get_Resize(5, 5);
 
                if (this.FillWithStrings.Checked == false)
                {
                    //Create an array.
                    double[,] saRet = new double[5, 5];
                    //Fill the array.
                    for (long iRow = 0; iRow < 5; iRow++)
                    {
                        for (long iCol = 0; iCol < 5; iCol++)
                        {
                            //Put a counter in the cell.
                            saRet[iRow, iCol] = iRow * iCol;
                        }
                    }
                    //Set the range value to the array;
                    range.set_Value(Missing.Value, saRet);
                }
                else
                {
                    //Create an array
                    string[,] saRet = new string[5, 5];
                    //Fill the array.
                    for (long iRow = 0; iRow < 5; iRow++)
                    {
                        for (long iCol = 0; iCol < 5; iCol++)
                        {
                            //put the row and colum address in the cell.
                            saRet[iRow, iCol] = iRow.ToString() + "|" + iCol.ToString();
                        }
                    }
                    //Set the range value to the array;
                    range.set_Value(Missing.Value, saRet);
                }
                //Return control of Execl to the user.
                objApp.Visible = true;
                objApp.UserControl = true;
            }
            catch (Exception theException)
            {
                string errorMessage;
                errorMessage = "Error";
                errorMessage = string.Concat(errorMessage, theException.Message);
                errorMessage = string.Concat(errorMessage, "Line:");
                errorMessage = string.Concat(errorMessage, theException.Source);
 
                MessageBox.Show(errorMessage, "Error");
            }
        }