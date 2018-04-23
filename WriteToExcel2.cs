namespace Printer
{
    public delegate void ProgressHandler();
 
    public class SaveExcel
    {
        private FileInfo template;
        private Application app;
        private object missing = Missing.Value;//用于调用带默认参数的方法
        public event ProgressHandler SavedEvent;
 
        public SaveExcel()
        {
            this.app = new Application();
            this.app.Visible = false;//设置Excel窗口不可见
            this.app.DisplayAlerts = false;//
            this.app.AlertBeforeOverwriting = false;//关闭修改之后是否保存
        }
 
 
        private void Save(string templatePath, string savePath, Order order)
        {
            template.CopyTo(savePath);//拷贝模板到要保存的路径
            Workbook book = app.Workbooks.Open(savePath, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);//打开拷贝的副本
            Worksheet sheet = book.Sheets[1] as Worksheet;//得到Excel的第一个sheet
            sheet.Cells[2, 1] = (sheet.Cells[2, 1] as Range).Text.ToString() + order.CreateDate;//在单元格的原有内容上追加内容
            sheet.Cells[2, 4] = (sheet.Cells[2, 4] as Range).Text.ToString() + order.DeliveryTime;
            sheet.Cells[2, 8] = (sheet.Cells[2, 8] as Range).Text.ToString() + order.OrderNo;
            sheet.Cells[4, 3] = order.ReservationManName;//向单元格写入数据
            sheet.Cells[4, 7] = order.ConsigneeAddress + "/" + order.ConsigneePhone;
            sheet.Cells[6, 9] = order.Remark;
            for (int i = 0; i < order.Items.Count && i < 5; i++)
            {
                sheet.Cells[6 + i, 1] = order.Items[i].ProductName;
                sheet.Cells[6 + i, 3] = order.Items[i].Unit;
                sheet.Cells[6 + i, 4] = order.Items[i].Amount;
                sheet.Cells[6 + i, 6] = order.Items[i].Price;
                sheet.Cells[6 + i, 8] = order.Items[i].Subtotal;
            }
            sheet.Cells[11, 3] = order.UpperTotalPrice;
            sheet.Cells[11, 8] = order.TotalPrice;
            book.Save();//保存Excel
        }
 
        // 保存单个订单
        public void SaveSingle(string templatePath, string fileName, Order order)
        {
            string savePath = Path.GetDirectoryName(fileName);// 获取文件路径的目录
            if (!Directory.Exists(savePath))//判断目录是否存在
                Directory.CreateDirectory(savePath); // 不存在就创建
            fileName = fileName.Insert(fileName.LastIndexOf('.'), order.OrderNo);// 把订单号添加到文件名后
            this.template = new FileInfo(templatePath);
            try
            {
                this.Save(templatePath, fileName, order);// 保存
                app.Workbooks.Close();// 关闭所有的Excel
            }
            finally
            {
                this.app.Quit();//退出Excel，结束进程
                System.GC.Collect();//回收资源
            }
        }
 
        // 保存多个订单
        public void SaveMultiple(string templatePath, string savePath, List<Order> list)
        {
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath); 
            this.template = new FileInfo(templatePath);
            try
            {
                foreach (Order order in list)
                {
                    this.Save(templatePath, savePath + "\\" + order.OrderNo + ".xls", order);
                    this.SavedEvent();
                }
                app.Workbooks.Close();
            }
            finally
            {
                this.app.Quit();
                System.GC.Collect();
            }
        }
    }
}