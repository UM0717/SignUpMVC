using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignUpMVC.ViewModels;

namespace SignUpMVC.Controllers
{
    public class SignUpController : Controller
    {

        private List<DataModel> _dataList = new List<DataModel>();
        
        public ActionResult SignUp()//Index()
        {
            ViewData["DataList"] = _dataList;
            return View();
            //return View(_dataList);
        }

        public ActionResult AddData(string name, string age, string birthday)
        {
            //var dataList = ViewData["DataList"] as List<DataModel>;
            
            //控制畫面開關
            bool isDivVisible = false;
            ViewBag.IsDivVisible = isDivVisible;

            int id =0;
            //if (_dataList == null)
            //    id = 1;
            //else
            //    id = _dataList.Count() + 1;

            //if (dataList == null)
            //{
            //    dataList = new List<DataModel>();
            //}

            //dataList.Add(new DataModel { Id=id , Name = name, Age = age, Birthday = birthday });

            //ViewData["DataList"] = dataList;

            //將先前資料存入變數
            List<DataModel> dataList = Session["DataList"] as List<DataModel>;
            if (Session["DataList"] != null)
            {
                //載入先前資料
                foreach (var i in dataList)
                {
                    _dataList.Add(new DataModel { Id =i.Id, Name = i.Name, Age = i.Age, Birthday = i.Birthday });
                }
            }
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(age) && !string.IsNullOrEmpty(birthday))
            {
                if (dataList.Count()==0)//(Session["DataList"] is null)
                    id = 1;
                else
                    id = Convert.ToInt16(_dataList.Max(a => a.Id) + 1);

                //新增
                _dataList.Add(new DataModel { Id = id, Name = name, Age = age, Birthday = birthday });
            }

            ViewData["DataList"] = _dataList;
            Session["DataList"] = _dataList;
            //return View("SignUp", dataList);
            return View("SignUp");
        }

        public ActionResult EditData(int id)
        {
            //控制畫面開關
            bool isDivVisible = true;
            ViewBag.IsDivVisible = isDivVisible;

            List<DataModel> dataList = Session["DataList"] as List<DataModel>;
            //var dataList = ViewData["DataList"] as List<DataModel>;

            //var data = dataList.FirstOrDefault(x => x.Id == id);

            foreach(var i in dataList)
            {
                _dataList.Add(new DataModel { Id = i.Id, Name = i.Name, Age = i.Age, Birthday = i.Birthday });
            }

            var data = _dataList.FirstOrDefault(x => x.Id == id);

            ViewData["DataList"] = _dataList;

            ViewData["Name"] = data.Name;
            ViewData["Age"] = data.Age;
            ViewData["Birthday"] = data.Birthday;
            ViewData["Id"] = data.Id;

            //新增
            ViewData["Id"] = id;
            if(data != null)
            {
                ViewData["Name"] = data.Name;
                ViewData["Age"] = data.Age;
                ViewData["Birthday"] = data.Birthday;
            }

            //return View("SignUp", data);
            return View("SignUp");
        }

        public ActionResult DeleteData(int id)
        {
            //控制畫面開關
            bool isDivVisible = false;
            ViewBag.IsDivVisible = isDivVisible;
            List<DataModel> dataList = Session["DataList"] as List<DataModel>;
            foreach (var i in dataList)
            {
                _dataList.Add(new DataModel { Id = i.Id, Name = i.Name, Age = i.Age, Birthday = i.Birthday });
            }

            _dataList.Remove(_dataList.FirstOrDefault(x => x.Id == id));

            ViewData["DataList"] = _dataList;
            Session["DataList"] = _dataList;
            return View("SignUp");
            //var dataList = ViewData["DataList"] as List<DataModel>;

            //var data = dataList.FirstOrDefault(x => x.Id == id);

            //dataList.Remove(data);

            //ViewData["DataList"] = dataList;

            //return View("SignUp", dataList);
        }


        public ActionResult UpdateData(string name, string age, string birthday, decimal id)
        {
            //控制畫面開關
            bool isDivVisible = false;
            ViewBag.IsDivVisible = isDivVisible;

            List<DataModel> dataList = Session["DataList"] as List<DataModel>;
            foreach (var i in dataList)
            {
                _dataList.Add(new DataModel { Id = i.Id, Name = i.Name, Age = i.Age, Birthday = i.Birthday });
            }

            var data = _dataList.FirstOrDefault(x => x.Id == id);

            if (data != null)
            {
                data.Name = name;
                data.Age = age;
                data.Birthday = birthday;
            }

            ViewData["DataList"] = _dataList;
            Session["DataList"] = _dataList;
            return View("SignUp");
        }

    }



}