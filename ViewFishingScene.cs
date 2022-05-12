using AssemblyCommon;
using Hotfix.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Hotfix.FishingCF
{
    public class ViewFishingScene : ViewMultiplayerScene
    {
        private GameObject canvas_gameobj;

        private AddressablesLoader.LoadTask<GameObject> canvas_;
        private GameObject canvas_gobj;

        public ViewFishingScene()
        {
            var gm = (GameControllerMultiplayer)AppController.ins.currentApp.game;
            gm.mainView = this;
        }

        public override void OnBankDepositChanged(msg_banker_deposit_change msg)
        {
            //throw new NotImplementedException();
        }

        public override void OnBankPromote(msg_banker_promote msg)
        {
            //throw new NotImplementedException();
        }

        public override void OnGameInfo(msg_game_info msg)
        {
            //throw new NotImplementedException();
        }

        public override void OnGameReport(msg_game_report msg)
        {
           // throw new NotImplementedException();
        }

        public override void OnGoldChange(msg_deposit_change2 msg)
        {
            //throw new NotImplementedException();
        }

        public override void OnGoldChange(msg_currency_change msg)
        {
            //throw new NotImplementedException();
        }

        public override void OnLastRandomResult(msg_last_random_base msg)
        {
            //throw new NotImplementedException();
        }

        public override void OnMyBet(msg_my_setbet msg)
        {
           // throw new NotImplementedException();
        }

        public override void OnNetMsg(int cmd, string json)
        {
            //throw new NotImplementedException();
        }

        public override void OnPlayerLeave(msg_player_leave msg)
        {
            //throw new NotImplementedException();
        }

        public override void OnPlayerSetBet(msg_player_setbet msg)
        {
            //throw new NotImplementedException();
        }

        public override void OnRandomResult(msg_random_result_base msg)
        {
            //throw new NotImplementedException();
        }

        public override void OnStateChange(msg_state_change msg)
        {
            //throw new NotImplementedException();
        }

        protected override void SetLoader()
        {
            LoadScene("Assets/Res/Games/FishingCF/Scenes/MainScene.unity", null);
        }

        protected override IEnumerator OnResourceReady()
        {
            yield return base.OnResourceReady();
            LoadAssets<GameObject>("Assets/Res/Games/FishingCF/Prefabs/Canvas.prefab", t => { canvas_ = t; });
            yield return Globals.resLoader.WaitForAllTaskCompletion();
            canvas_gobj = canvas_.Instantiate();

        }
    }
}
