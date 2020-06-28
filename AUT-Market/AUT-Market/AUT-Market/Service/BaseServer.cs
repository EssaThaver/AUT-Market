using Newtonsoft.Json;
using Qiniu;
using Qiniu.Storage;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AUT_Market.Service
{
    public class BaseServer
    {
        public static string baseurl = "http://qcm4kzcjt.bkt.clouddn.com/";// qb3ggg6va.bkt.clouddn.com
        public static string AccessKey = "3btf_FpEEgt0_6U1kND-EG0s8TWGII9YC-6M6YIe";
        public static string SecretKey = "IEd4e36dMIIy-HbuktCvvbPZHp_FJVL9KmSbJ46x";
        public static string Bucket = "autmarket1";


        public async static Task<Dictionary<string, string>> UpdateImage(string filePath) {
            var dic = new Dictionary<string, string>()
            {
                ["code"] = "1001"
            };
            try
            {
                var imgtype = filePath.Substring(filePath.LastIndexOf("."));
                var config = new Config
                {
                    Zone = Zone.ZoneCnSouth
                };
                var saveKey = Guid.NewGuid() + imgtype;//目标文件名

                var putPolicy = new PutPolicy { Scope = Bucket };
                putPolicy.SetExpires(3600);
                var mac = new Mac(AccessKey, SecretKey);
                var token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());

                var um = new UploadManager(config);
                Qiniu.Http.HttpResult result = await um.UploadFile(filePath, saveKey, token, null);
                var dicc = JsonConvert.DeserializeObject<Dictionary<string, string>>(result.Text);
                if (dicc.ContainsKey("hash"))
                {
                    dic["code"] = "1000";
                    dic["hash"] = dicc["hash"];
                    dic["key"] = dicc["key"];
                }
                else
                {
                    dic["message"] = dicc["error"];
                }
            }
            catch (Exception ex)
            {
                dic["message"] = ex.Message;
            }
            return dic;
        }
    }
}
