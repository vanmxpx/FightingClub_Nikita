using GameProcess;
using System;
using System.Windows.Forms;

namespace FightingClub_Nikita
{
    class Presenter
    {
        MainForm _view;
        Logic _process;
        LogManager _log;

        public Presenter(MainForm _view, LogManager _log)
        {
            _process = new Logic(_view.NamePlayer1);
            _view.NamePlayer2 = _process.player2.Name;
            this._view = _view;
            this._log = _log;

            _view.ButHeadClick += new EventHandler(_view_ButHeadClick);
            _view.ButBodyClick += new EventHandler(_view_ButBodyClick);
            _view.ButLegClick += new EventHandler(_view_ButLegClick);

            _process.player1.Block += new EventHandler<MyEventArgs>(_view_AddLogInfoBlock);
            _process.player1.Wound += new EventHandler<MyEventArgs>(_view_AddLogInfoWound);
            _process.player1.Death += new EventHandler<MyEventArgs>(_view_EndGame);

            _process.player2.Block += new EventHandler<MyEventArgs>(_view_AddLogInfoBlock);
            _process.player2.Wound += new EventHandler<MyEventArgs>(_view_AddLogInfoWound);
            _process.player2.Death += new EventHandler<MyEventArgs>(_view_EndGame);

            UpdateStats();
        }

        public void UpdateStats()
        {
            _view.HPPlayer1 = _process.player1.HealthPoints;
            _view.HPPlayer2 = _process.player2.HealthPoints;
            _view.Rounds = _process.Round;
            _view.Title = (_process.Round % 2 == 0) ? true : false;
        }

        #region Forms' events
        private void _view_ButHeadClick(object sender, EventArgs e)
        {
            _process.MakeStep(BodyParts._head);
            UpdateStats();
        }

        private void _view_ButBodyClick(object sender, EventArgs e)
        {
            _process.MakeStep(BodyParts._body);
            UpdateStats();
        }

        private void _view_ButLegClick(object sender, EventArgs e)
        {
            _process.MakeStep(BodyParts._leg);
            UpdateStats();
        }
        #endregion

        #region Logics' events
        private void _view_EndGame(object sender, MyEventArgs e)
        {
            _view.AddLog = e.Name + "is dead!";
            string winner = (sender == _process.player1) ? _process.player2.Name : _process.player1.Name;
            MessageBox.Show(e.Name + " is dead!", winner + " win!", MessageBoxButtons.OK);
            _view.BlockGame(winner);
        }

        private void _view_AddLogInfoWound(object sender, MyEventArgs e)
        {
            _view.AddLog = e.Name + " taked damage! Now he has " + e.HP;
        }

        private void _view_AddLogInfoBlock(object sender, MyEventArgs e)
        {
            _view.AddLog = e.Name + " blocked attack!";
        }
        #endregion
    }
}
