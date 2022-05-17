using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotfix.FishingCF
{
    public class LanguageErrcode
    {
        public static List<LanguageErrcodeItem> languageErrcodeItems = new List<LanguageErrcodeItem>()
        {
            new LanguageErrcodeItem(1,"CLGTHandAck_1","无法识别的平台"),
            new LanguageErrcodeItem(2,"CLGTHandAck_2","无法识别的产品"),
            new LanguageErrcodeItem(3,"CLGTHandAck_3","版本太老需强更"),
            new LanguageErrcodeItem(4,"CLGTHandAck_4","拒绝访问"),
            new LanguageErrcodeItem(5,"CLGTHandAck_5","你的IP已被封禁"),
            new LanguageErrcodeItem(6,"CLGTHandAck_6","你的设备已被封禁"),
            new LanguageErrcodeItem(7,"CLGTLoginAck_1","平台服务器不可用"),
            new LanguageErrcodeItem(8,"CLGTLoginAck_2","账号被封禁"),
            new LanguageErrcodeItem(9,"CLGTLoginAck_3","系统繁忙"),
            new LanguageErrcodeItem(10,"CLGTLoginAck_4","系统错误"),

            new LanguageErrcodeItem(11,"CLGTLoginAck_5","系统暂未开放"),
            new LanguageErrcodeItem(12,"CLGTAccessServiceAck_1","服务不存在"),
            new LanguageErrcodeItem(13,"CLGTAccessServiceAck_2","拒绝访问"),
            new LanguageErrcodeItem(14,"CLPFItemUseAck_1","数量不足"),
            new LanguageErrcodeItem(15,"CLPFItemUseAck_2","配置表错误"),
            new LanguageErrcodeItem(16,"CLPFItemUseAck_3","使用失败"),
            new LanguageErrcodeItem(17,"CLPFItemUseAck_4","鱼潮即将来临禁止使用"),
            new LanguageErrcodeItem(18,"CLPFItemUseAck_5","狂暴下不能使用瞄准"),
            new LanguageErrcodeItem(19,"CLPFItemUseAck_6","分身下不能使用瞄准"),
            new LanguageErrcodeItem(20,"CLPFItemUseAck_7","vip等级不足"),

        };
    }
    public class LanguageErrcodeItem
    {

        public int Id;
        public string key;
        public string CN;

        public LanguageErrcodeItem(int id, string key, string cN)
        {
            Id = id;
            this.key = key;
            CN = cN;
        }
    }
}
