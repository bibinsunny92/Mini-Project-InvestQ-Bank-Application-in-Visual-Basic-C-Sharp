using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;

namespace Assignment04_Sebastian_BibinSunny
{
    public partial class Form1 : Form
    {
        // defining the variables
        double Principal;
        double rateFirstmonth, rateThirdmonth, rateSixthmonth, rateTwelthmonth;
        double accrudedCompoundinterest = 0;
        double sumCompoundinterest      = 0;
        double sumBalancevalue          = 0;
        double totalPrincipalamount     = 0;
        const int BONUS                 = 5000;                                  // assigning constant value to Bonus
        const int FIRSTTERM = 1, THIRDTERM = 3, SIXTHTERM = 6, TWELTHTERM = 12;  // assigning constant value to Term
        double rate, balanceValue;
        int months;
        int count;
        int flagValue = 0;

        //private void summaryGroupbox_Enter(object sender, EventArgs e)
        //{

        //}
        //private void Form1_Load_1(object sender, EventArgs e)
        //{

        //}

        //private void proceedButton_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void confirmButton_Click_1(object sender, EventArgs e)
        //{

        //}
        //private void displayGroupbox_Enter(object sender, EventArgs e)
        //{

        //}

        public Form1()
        {
            InitializeComponent();
            this.Text = "InvestQ Application";
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // hiding the group boxes initially
            planGroupbox.Visible        = false;
            transactionGroupbox.Visible = false;
            displayGroupbox.Visible     = false;
            summaryGroupbox.Visible     = false;
            summaryButton.Enabled       = false;
            clearButton.Enabled         = false;
        }

        private void displayButton_Click_2(object sender, EventArgs e)
        {
            //planGroupbox.Visible = true;
            //tableLayoutPanel1.Visible = true;
            //Principal = double.Parse(PrincipalTextbox.Text);
            //if (Principal <= 100000)
            //{
            //    rateFirstmonth = 0.50000;
            //    rateThirdmonth = 0.62500;
            //    rateSixthmonth = 0.71250;
            //    rateTwelthmonth = 1.12500;
            //}
            //else
            //{
            //    rateFirstmonth = 0.60000;
            //    rateThirdmonth = 0.72500;
            //    rateSixthmonth = 0.81250;
            //    rateTwelthmonth = 1.25000;
            //}
            //firstBalancelabel.Text = CalculateCompoundedBalance(FIRSTTERM, Principal, rateFirstmonth).ToString();
            //firstRatelabel.Text = rateFirstmonth.ToString();
            //thirdBalancelabel.Text = CalculateCompoundedBalance(THIRDTERM, Principal, rateThirdmonth).ToString();
            //thirdRatelabel.Text = rateThirdmonth.ToString();
            //sixBalancelabel.Text = CalculateCompoundedBalance(SIXTHTERM, Principal, rateSixthmonth).ToString();
            //sixRatelabel.Text = rateSixthmonth.ToString();
            //twelveBalancelabel.Text = CalculateCompoundedBalance(TWELTHTERM, Principal, rateTwelthmonth).ToString();
            //twelveRatelabel.Text = rateTwelthmonth.ToString();
        }
   
        private double CalculateCompoundedBalance(int Month, double Amount, double Rate)
        {
            // Calculation of compound interest
            double FinalBalance = 0;
            if(Amount > 100000 && Month >= SIXTHTERM)
            {
                FinalBalance = (Amount * (Math.Pow(1 +(Rate / (12 * 100)), Month))) + BONUS; // Adding Bonus to the final amount, if principal is greater than 1 Lakh for 6 or more monnths
            }
            else
            {
                FinalBalance = (Amount * (Math.Pow(1 + (Rate / (12 * 100)), Month)));
            }
            return FinalBalance;
        }

        private void displayButton_Click_1(object sender, EventArgs e)
        {
            planGroupbox.Visible      = true;
            tableLayoutPanel1.Visible = true;
            Principal = double.Parse(PrincipalTextbox.Text);
            if (Principal <= 100000)                      // first case when principal amount is less than or equal to 1 Lakh
            {
                rateFirstmonth  = 0.50000;                // Corresponding interest rates when principal amount is less than or equal to 1 Lakh
                rateThirdmonth  = 0.62500;
                rateSixthmonth  = 0.71250;
                rateTwelthmonth = 1.12500;
            }
            else
            {
                rateFirstmonth  = 0.60000;               // Interest rates when principal amount is greater than 1 Lakh
                rateThirdmonth  = 0.72500;
                rateSixthmonth  = 0.81250;
                rateTwelthmonth = 1.25000;
            }
            firstBalancelabel.Text  = CalculateCompoundedBalance(FIRSTTERM, Principal, rateFirstmonth).ToString("c", new CultureInfo("en-FR"));
            firstRatelabel.Text     = rateFirstmonth.ToString();
            thirdBalancelabel.Text  = CalculateCompoundedBalance(THIRDTERM, Principal, rateThirdmonth).ToString("c", new CultureInfo("en-FR"));
            thirdRatelabel.Text     = rateThirdmonth.ToString();
            sixBalancelabel.Text    = CalculateCompoundedBalance(SIXTHTERM, Principal, rateSixthmonth).ToString("c", new CultureInfo("en-FR"));
            sixRatelabel.Text       = rateSixthmonth.ToString();
            twelveBalancelabel.Text = CalculateCompoundedBalance(TWELTHTERM, Principal, rateTwelthmonth).ToString("c", new CultureInfo("en-FR"));
            twelveRatelabel.Text    = rateTwelthmonth.ToString();
        }

        private void proceedButton_Click_1(object sender, EventArgs e)      // Logic when the user clicks Proceed Button
        {
            transactionGroupbox.Visible = true;
            if (firstRadiobutton.Checked)                                   
            {
                // If term selected is 1 month
                Principal = double.Parse(PrincipalTextbox.Text);
                rate         = double.Parse(firstRatelabel.Text);
                months       = int.Parse(firstMonthlabel.Text);
                balanceValue = CalculateCompoundedBalance(FIRSTTERM, Principal, rateFirstmonth);
                //balanceValue = double.Parse(firstBalancelabel.Text);

            }
            else if (thirdRadiobutton.Checked)                              
            {
                // If term selected is for 3 months
                Principal    = double.Parse(PrincipalTextbox.Text);
                rate         = double.Parse(thirdRatelabel.Text);
                months       = int.Parse(thirdMonthlabel.Text);
                balanceValue = CalculateCompoundedBalance(THIRDTERM, Principal, rateThirdmonth);
                //balanceValue = double.Parse(thirdBalancelabel.Text);
            }
            else if (sixthRadiobutton.Checked)                              
            {
                // If term selected is for 6 months
                Principal    = double.Parse(PrincipalTextbox.Text);
                rate         = double.Parse(sixRatelabel.Text);
                months       = int.Parse(sixMonthlabel.Text);
                balanceValue = CalculateCompoundedBalance(SIXTHTERM, Principal, rateThirdmonth);
                //balanceValue = double.Parse(sixBalancelabel.Text);
            }
            else if (twelthRadiobutton.Checked)                             
            {
                // If term selected is for 12 months
                Principal    = double.Parse(PrincipalTextbox.Text);
                rate         = double.Parse(twelveRatelabel.Text);
                months       = int.Parse(twelveMonthlabel.Text);
                balanceValue = CalculateCompoundedBalance(TWELTHTERM, Principal, rateThirdmonth);
                //balanceValue = double.Parse(twelveBalancelabel.Text);
            }
            else MessageBox.Show("Please select your plan");                // Exception handling if the user hasn't selected anything 
        }

        //private void searchListbox_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        private void confirmButton_Click_1(object sender, EventArgs e)      // Logic when the user clicks the confirm button
        {
            bool transactionValid = false, nameValid = false, phoneValid = false, emailValid = false;
            transactionValid = Regexp(@"^\d{6}$", transactionTextbox, transactionValid, transactionLbl, "Transaction No");          //Using Regular expression to make sure transaction no should have 6 digits
            nameValid        = Regexp(@"^[a-zA-Z\s]+$", clientTextbox, nameValid, clientLbl, "Client Name");                        //Using Regular expression to make sure client name value should include alphabets only
            phoneValid       = Regexp(@"^(353)(([ ][0-9]{3}){3})$", telephoneTextbox, phoneValid, telephoneLbl, "Phone Number");    //Using Regular expression to make sure Telephone no is of digits and in format (0353) XXXXX XXXXX
            emailValid       = Regexp(@"^([\w]+)@([\w]+)\.([\w]+)$", emailTextbox, emailValid, emailLbl, "Mail");                   //Using Regular expression to make sure email id displayed should have @ as well as a . 

            if (transactionValid && nameValid && phoneValid && emailValid)
            {
                displayGroupbox.Visible = true;
                principalLabel.Text   = Principal.ToString("c", new CultureInfo("en-FR"));
                rateLabel.Text        = rate.ToString();
                termLabel.Text        = months.ToString();
                finalLabel.Text       = balanceValue.ToString("c", new CultureInfo("en-FR"));
                transactionLabel.Text = transactionTextbox.Text;
                clientLabel.Text      = clientTextbox.Text;
                telephoneLabel.Text   = telephoneTextbox.Text;
                emailLabel.Text       = emailTextbox.Text;

                DialogResult result = MessageBox.Show("Are you sure you want to execute the transaction?", "Final Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Your transaction has been processed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StreamWriter OutputFile;
                    OutputFile = File.AppendText("Transaction_Details.txt");                  // code to make sure, in case of sucessful trnsaction the records should be written on the text file
                    OutputFile.WriteLine("TRANSACTION NO:" + transactionLabel.Text + ";" + "PRINCIPAL AMOUNT:" + principalLabel.Text + ";" + "ACCRUED BALANCE:" + finalLabel.Text + ";" +"RATE:" + rateLabel.Text + ";" + "TERM:" + termLabel.Text + ";" +  "CLIENT NAME:" + clientLabel.Text + ";" + "TELEPHONE NO:" + telephoneLabel.Text + ";" + "EMAIL ADDRESS:" + emailLabel.Text);
                    OutputFile.Close();
                    displayGroupbox.Visible     = false;
                    transactionGroupbox.Visible = false;

                    count = count + 1;
                    accrudedCompoundinterest    = balanceValue - Principal;
                    totalPrincipalamount        = totalPrincipalamount + Principal;
                    sumCompoundinterest         = sumCompoundinterest + accrudedCompoundinterest;
                    sumBalancevalue             = sumBalancevalue + balanceValue;

                }
                else
                {
                    MessageBox.Show("Transaction has failed to execute. Please try again!");   // in case the user clicks No button meaning s/he doesnt wish to proceed with the transaction
                    displayGroupbox.Visible = false;                   
                }
            }
            summaryButton.Enabled = true;
            clearButton.Enabled   = true;

        }
        public bool Regexp(string re, TextBox tb, bool valid, Label lbl, string s)      //Regular expression logic
        {
            Regex regex = new Regex(re);

            if (regex.IsMatch(tb.Text))
            {
                lbl.Text = s + " is Valid";         // message to be displayed when the client put correct details
                lbl.ForeColor = Color.Green;        // The display message should be in green color when format is correct
                valid = true;
            }
            else
            {
                lbl.Text = s + " is InValid";      // message to be displayed when the client put incorrect information
                lbl.ForeColor = Color.Red;         // The display message should be in red color when format is incorrect
                valid = false;
            }
            return valid;
        }

        private void summaryButton_Click(object sender, EventArgs e)            // Logic for Summary button
        {
            foreach (var line in File.ReadAllLines("Transaction_Details.txt"))  // To read information from the text file
            {
                var TransactNo = line.Substring(15, 6);                         // code which reads all the transaction No information from the file
                summaryListBox.Items.Add(TransactNo);                           // code which picks all the transaction No from the file and displays it in the listbox field
                investedAmountlabel.Text = totalPrincipalamount.ToString("c", new CultureInfo("en-FR"));
                accruedAmountlabel.Text  = sumBalancevalue.ToString("c", new CultureInfo("en-FR"));
                avgDurationlabel.Text    = (sumCompoundinterest / count).ToString("c", new CultureInfo("en-FR"));
            }
            summaryGroupbox.Visible      = true;
            transactionGroupbox.Visible  = false;
            //Changing the labels to blanks for transaction groupbox
            transactionLbl.Text          = "";          
            clientLbl.Text               = "";
            telephoneLbl.Text            = "";
            emailLbl.Text                = "";
            transactionTextbox.Text      = "";
            clientTextbox.Text           = "";
            telephoneTextbox.Text        = "";
            emailTextbox.Text            = "";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // Below is code when user searches for a transaction, the correspondent details should be fetched from the text file  
            String searchID, searchEmail;
            searchListbox.Items.Clear();
            if (tranIDtextbox.Text != "")
            {
                searchID = tranIDtextbox.Text;       // case when user decides to search for transaction using transaction ID
                search(searchID);
            }
            else
            {
                searchEmail = idTextbox.Text;       //  case when user decides to search for transaction using email ID
                search(searchEmail);
            }
        }

        private void search(string r)
        {
            try
            {
                String line;
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("Transaction_Details.txt");
                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    if (line.Contains(r))
                    {
                        searchListbox.Items.Add(line);
                        flagValue = 1;              // indicating transaction found
                    }

                    //write the lie to console window
                    //Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                if (flagValue == 0)                 // indicating transaction found
                {
                    MessageBox.Show("Transaction not found", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);   // Exception handling if the transaction searched is not found
                }
            }
            catch
            {
                MessageBox.Show("File not found", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);               // Exception handling if the file transaction.txt is not present
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // To clear all the selection that user has made
            transactionTextbox.Text     = "";
            clientTextbox.Text          = "";
            telephoneTextbox.Text       = "";
            emailTextbox.Text           = "";
            transactionGroupbox.Visible = false;
            firstRadiobutton.Checked    = false;
            thirdRadiobutton.Checked    = false;
            sixthRadiobutton.Checked    = false;
            twelthRadiobutton.Checked   = false;
            planGroupbox.Visible        = false;
            investedAmountlabel.Text    = "";
            accruedAmountlabel.Text     = "";
            avgDurationlabel.Text       = "";
            summaryGroupbox.Visible     = false;
            PrincipalTextbox.Text       = "";
            transactionLbl.Text         = "";
            clientLbl.Text              = "";
            telephoneLbl.Text           = "";
            emailLbl.Text               = "";
        }


        private void exitButton_Click(object sender, EventArgs e)
        {
            //For exiting the application
            this.Close();
            Application.Exit();
        }
    }
}
