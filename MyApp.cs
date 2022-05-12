using Hotfix.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hotfix.FishingCF
{
	public class MyApp : AppBase
	{
		public ThisGameConfig conf = new ThisGameConfig();
		public GameController theGame = new GameController();
 
		public override void Start()
		{
			game = theGame;
			conf.Init();
			base.Start();

		}
	}
}
