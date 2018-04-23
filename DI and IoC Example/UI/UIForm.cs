using System;
using System.Windows.Forms;
using TaskExecutors;
using Logger;

namespace UI
{
    public partial class UIForm : Form
    {
        private readonly IDrink drinker; // = new WaterDrinker(new TextFileLogger());
        private readonly IComplicated genius; // = new MedicalResearcher(new TextFileLogger());
        private readonly ICharitable nicePerson; // = new DoGooder(new ConsoleLogger());
        private readonly INoisy noiseMaker; // = new CarHorn(new ConsoleLogger());

        //constructor
        public UIForm(IDrink drinker,
                      IComplicated genius,
                      ICharitable nicePerson,
                      INoisy noiseMaker)
        {
            this.drinker = drinker;
            this.genius = genius;
            this.nicePerson = nicePerson;
            this.noiseMaker = noiseMaker;


            InitializeComponent();
        }

        private void performSortButton_Click(object sender, EventArgs e)
        {
            genius.PerformComplicatedTask();
        }

        private void takeDrinkButton_Click(object sender, EventArgs e)
        {
            drinker.TakeDrink();
        }

        private void makeNoiseButton_Click(object sender, EventArgs e)
        {
            noiseMaker.MakeNoise();
        }

        private void somethingGoodButton_Click(object sender, EventArgs e)
        {
            nicePerson.DoSomethingGood();
        }
    }
}