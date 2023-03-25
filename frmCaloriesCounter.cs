using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CaloriesCounterWithUserInput
{
    public partial class frmCaloriesCounter : Form
    {
        public frmCaloriesCounter()
        {
            InitializeComponent();
        }

        string[] Days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
        string[] MealTime = { "Breakfast", "Morning Snack", "Lunch", "Afternoon Snack", "Dinner"};
        int[,] Calories = new int [7,5];
        double[] DailyAv = { };
        double[] MealtimeAv =  { };
        int[] LargestRow = { };
        int [] LargestCol = { };

        private void frmCaloriesCounter_Load(object sender, EventArgs e)
        {
            
            cbxDays.Items.AddRange(Days);
            cbxMeal.Items.AddRange(MealTime);

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain form1 = new frmMain();
            form1.BringToFront();
            this.Close();
        }

        private int[,] RandomCalories(int[,] Calories)
        {
            Random number = new Random();
            for (int row = 0; row < Calories.GetLength(0); row++)
            {
                for (int col = 0; col < Calories.GetLength(1); col++)
                {
                    
                    Calories[row, col] += number.Next(200, 1500);
                }
            }


            return Calories;

        }

        private void DisplayCalories()
        {
            int i = 0;
            string result = "";
            result += "\t";
            for ( i = 0; i < MealTime.GetLength(0); i++)
            {
                result += string.Format("{0}\t", MealTime[i]);
            }

            result += "\n";
            
            for ( i = 0; i < Days.GetLength(0); i++)
            {
                result += String.Format("\n{0, -10}:\n" , Days[i]);
                 for (i = 0; i < Calories.GetLength(0); i++)
                    {
                        result += String.Format("{0}\t", Calories[i, 1]);
                    }
                
                
            }

            
            

            MessageBox.Show(result, "Weekly Calory Intake Summary");
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomCalories(Calories);
            DisplayCalories();
            
        }


        public double[] CalculateDailyAverage(int[,] Calories)
        {
            int sum = 0;
            double[] dailyav = new double[7];
            for (int row = 0; row < Calories.GetLength(0); row++)
            {
                for (int col = 0; col < Calories.GetLength(1); col++)
                    sum += Calories[row, col];
                    dailyav[row] = (double)sum / Calories.GetLength(1);
                    sum = 0;


            }
            return dailyav;
        }

        public double[] CalculateMealAverage(int[,] Calories)
        {
            int sum = 0;

            double[] mealav = new double[5];
            for (int col=0; col<Calories.GetLength(1); col++)
            {
                for (int row = 0; row < Calories.GetLength(0); row++)
                    sum += Calories[row, col];

                mealav[col] = (double)sum / Calories.GetLength(0);
                sum = 0;

            }
            return mealav;
        }

        public void FindLargest(int[,] Calories, ref int largestRow, ref int largestCol)
        {
            for (int row = 0; row < Calories.GetLength(0); row++)
            {
                for (int col = 0; col < Calories.GetLength(1); col++)
                {
                    if (Calories[row, col] > Calories[largestRow, largestCol])
                    {
                        largestRow = row;
                        largestCol = col;
                    }
                }
            }
        }
    }
}
