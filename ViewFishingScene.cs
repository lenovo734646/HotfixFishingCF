using AssemblyCommon;
using Hotfix.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace Hotfix.FishingCF
{
    public class ViewFishingScene : ViewMultiplayerScene
    {
        private GameObject canvas_gameobj;

        private AddressablesLoader.LoadTask<GameObject> canvas_;
        private GameObject canvas_gobj;

        //-------一些基本变量-----------
        private float leftMoveSpeed_ = 1.0f;

        //选房系统
        private GameObject selectRoomSys_;
        //渔场系统
        private GameObject fishSys_;
        //帮助系统
        private GameObject helpSys_;
        //设置系统
        private GameObject settingSys_;

        //GameUI
        private GameObject gameUi_;

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

            selectRoomSys_ = canvas_gobj.FindChildDeeply(GlobalKeys.SelectRoomSys);
            fishSys_ = canvas_gobj.FindChildDeeply(GlobalKeys.FishSys);
            helpSys_ = canvas_gobj.FindChildDeeply(GlobalKeys.HelpSys);
            settingSys_ = canvas_gobj.FindChildDeeply(GlobalKeys.SettingSys);
            gameUi_ = fishSys_.FindChildDeeply("GameUI");

            //打开选房系统
            OpenSelectRoom(selectRoomSys_);
            //打开右边面板

            var move_leftUi = gameUi_.FindChildDeeply("LeftUI");
            LeftUi(move_leftUi);
        }
        /// <summary>
        /// 打开选房界面
        /// </summary>
        /// <param name="room_ui">选房界面</param>
        private void OpenSelectRoom(GameObject room_ui) 
        {
            room_ui.SetActive(true);
            var room_00_btn = room_ui.FindChildDeeply("RoomUI").FindChildDeeply("Room").FindChildDeeply("Room_00").GetComponent<Button>();
            room_00_btn.onClick.AddListener(() =>
            {
                room_ui.SetActive(false);
                OpenFishSys(fishSys_);
            });

            var room_01_btn = room_ui.FindChildDeeply("RoomUI").FindChildDeeply("Room").FindChildDeeply("Room_01").GetComponent<Button>();
            room_01_btn.onClick.AddListener(() =>
            {
                room_ui.SetActive(false);
                OpenFishSys(fishSys_);
            });

            var room_02_btn = room_ui.FindChildDeeply("RoomUI").FindChildDeeply("Room").FindChildDeeply("Room_02").GetComponent<Button>();
            room_02_btn.onClick.AddListener(() => {
                room_ui.SetActive(false);
                OpenFishSys(fishSys_);
            });

        }

        /// <summary>
        /// 显示捕鱼游戏界面
        /// </summary>
        /// <param name="fish_ui">捕鱼游戏界面</param>
        private void OpenFishSys(GameObject fish_ui) 
        {
            fish_ui.SetActive(true);

        }

        /// <summary>
        /// 往左边移动界面
        /// </summary>
        /// <param name="move_leftUi">左移的界面</param>
        private void LeftUi(GameObject leftUi) 
        {
            var Group = leftUi.FindChildDeeply("Group");
            var btnExplain = Group.FindChildDeeply("btnExplain").GetComponent<Button>();
            var btnSet = Group.FindChildDeeply("btnSet").GetComponent<Button>();
            var btnClose = Group.FindChildDeeply("btnClose").GetComponent<Button>();
            var btnArrows = leftUi.FindChildDeeply("Arrows").GetComponent<Button>();
           
            //移动侧边界面
            var isLeftMove = false;
            btnArrows.onClick.AddListener(() =>
            {
                var rectLeft = leftUi.GetComponent<RectTransform>();
                if (!isLeftMove)
                {
                    var doMove = rectLeft.DOLocalMoveX(864, leftMoveSpeed_);
                }
                else
                {
                    var doMove = rectLeft.DOLocalMoveX(1056, leftMoveSpeed_);
                }
                isLeftMove = !isLeftMove;

            });

            //鱼种
            btnExplain.onClick.AddListener(() => {
                OpenHelpSys(helpSys_);
            });

            //设置
            btnSet.onClick.AddListener(() => { OpenSettingSys(settingSys_); });
            //离开 todo

        }

        //鱼种界面
        private void OpenHelpSys(GameObject helpSys) 
        {

            helpSys.SetActive(true);
            var Help = helpSys.FindChildDeeply("FishHandBookUI").FindChildDeeply("Help");

            if (Help != null)
            {
                var closeBtn = Help.FindChildDeeply("Close").GetComponent<Button>();
                closeBtn.onClick.AddListener(() => 
                {
                    helpSys.SetActive(false);
                });

                //todo 鱼种介绍
                

            }
        }

        //设置界面
        private void OpenSettingSys(GameObject SettingSys) 
        {
            SettingSys.SetActive(true);

            var set = SettingSys.FindChildDeeply("SetUI").FindChildDeeply("Set");
            if (set != null)
            {
                var closeBtn = set.FindChildDeeply("Close").GetComponent<Button>();

                
                //music toggle 
                var musicBtn = set.FindChildDeeply("Music").FindChildDeeply("Toggle").GetComponent<Button>();
                musicBtn.onClick.AddListener(() => {
                    SwichShowChild(musicBtn.gameObject);
                });
                //sound toggle 
                var soundBtn = set.FindChildDeeply("Sound").FindChildDeeply("Toggle").GetComponent<Button>();
                soundBtn.onClick.AddListener(() => { SwichShowChild(soundBtn.gameObject); });

                //关闭
                closeBtn.onClick.AddListener(() =>
                {
                    SettingSys.SetActive(false);
                    musicBtn.onClick.RemoveAllListeners();
                    soundBtn.onClick.RemoveAllListeners();
                });
            }
        }

        private void SwichShowChild(GameObject parent)
        {

            for (int i = 0; i < parent.transform.childCount; i++)
            {
                var child = parent.transform.GetChild(i);
                child.gameObject.SetActive(!child.gameObject.activeSelf);
            }

        }
    }
}
