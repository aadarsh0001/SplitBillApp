namespace SplitBillApp;

public partial class MainPage : ContentPage
{
    decimal bill;
    int tip;
    int noPerson = 1;
    public MainPage()
    {
        InitializeComponent();
    }

    private void txtBill_Completed(object sender, EventArgs e)
    {
        bill = decimal.Parse(txtBill.Text);
        CalculateTotal();

    }

    private void CalculateTotal()
    {
        // Total Tip
        var totalTip = (bill * tip) / 100;

        // Tip by Person
        var tipByPerson = (totalTip / noPerson);
        lblTip.Text = $"{tipByPerson}";

        // sub total
        var subTotal = (bill / noPerson);
        lblSubTotal.Text = $"{subTotal}";

        //total
        var totalByPerson = (bill + totalTip) / noPerson;
        lblTotal.Text = $"{totalByPerson}";
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            var btn = (Button)sender;
            var percentage = int.Parse(btn.Text.Replace("%", ""));
            sldTip.Value = percentage;
        }
    }

    private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        tip = (int)sldTip.Value;
        lblTip.Text = $"Tip: {tip}";
        CalculateTotal();
    }

    private void btnMinus_Clicked(object sender, EventArgs e)
    {
        if (noPerson > 1)
        {
            noPerson--;
            lblNoPerson.Text = noPerson.ToString();
            CalculateTotal();
        }
    }

    private void btnPlus_Clicked(object sender, EventArgs e)
    {
        noPerson++;
        lblNoPerson.Text = noPerson.ToString();
        CalculateTotal();
    }
}

