namespace ListOfGoods.Infrastructure.Models
{
    public class EditPurchaseModel
    {
        public string NewPurchase { get; set; }
        public bool ImageIconIsCustom { get; set; }
        public int PurchasesId { get; set; }
        public string PurchaseIconImagePath { get; set; }
        public string SelectedCategory { get; set; }
        public int Id { get; set; }
        public int PurchasesListId { get; set; }
        public string Quantity { get; set; }
        public string SelectedMesurement { get; set; }
        public string Price { get; set; }
        public int SelectedIndexOfMesurement { get; set; }
        public int SelectedIndexCategory { get; set; }
        public int SelectedIndexCurrency { get; set; }
        public string SelectedCurrency { get; set; }
    }
}
