namespace datatechtyache.Models
{
    public class Temp_PrintPlan
    {
        public long TempPlanID { get; set; } // Auto-generated primary key
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string BatchNumber { get; set; }
        public string DLNumber { get; set; }
        public string GrossWeight { get; set; }
        public string TareWeight { get; set; }
        public string NetWeight { get; set; }
        public string MfgDate { get; set; }
        public string ExpDate { get; set; }
        public string UPCNo { get; set; }
        public string Storage { get; set; }
        public string ContainerNumber { get; set; }
        public string LabelCode { get; set; }
        public string CaseNo { get; set; }
        public string ErrorLog { get; set; }
        public bool IsValid { get; set; }
        public long TransUserId { get; set; }
        public long TransSessionID { get; set; }
        public DateTime TransTime { get; set; }
    }
}
