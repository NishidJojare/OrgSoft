using OrgSoft.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace OrgSoft.Models
{
    public class TeamModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Photo { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string LinkedIn { get; set; }

        public string SaveTeam(HttpPostedFileBase fb, TeamModel model)
        {
            string msg = "";
            OrgSoftEntities db = new OrgSoftEntities();
            string filepath = "";
            string fileName = "";
            string sysFileName = "";
            if (fb != null && fb.ContentLength > 0)
            {
                filepath = HttpContext.Current.Server.MapPath("~/Content/Img/");
                DirectoryInfo di = new DirectoryInfo(filepath);
                if (!di.Exists)
                {
                    di.Create();
                }
                fileName = fb.FileName;
                sysFileName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb.FileName);
                fb.SaveAs(filepath + "//" + sysFileName);
                if (!string.IsNullOrWhiteSpace(fb.FileName))
                {
                    string afileName = HttpContext.Current.Server.MapPath("~/Content/Img/") + "/" + sysFileName;
                }
            }
            if (model.Id == 0)
            {
                var SaveUser = new tblTeam()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Designation = model.Designation,
                    Photo = sysFileName,
                    Instagram = model.Instagram,
                    Facebook = model.Facebook,
                    Twitter = model.Twitter,
                    LinkedIn = model.LinkedIn


                };
                db.tblTeams.Add(SaveUser);
                db.SaveChanges();
                return msg;
            }
            else
            {
                var aboutData = db.tblTeams.Where(p => p.Id == model.Id).FirstOrDefault();
                if (aboutData != null)
                {
                    aboutData.Id = model.Id;
                    aboutData.Name = model.Name;
                    aboutData.Designation = model.Designation;
                    aboutData.Photo = sysFileName;
                    aboutData.Instagram = model.Instagram;
                    aboutData.Facebook = model.Facebook;
                    aboutData.Twitter = model.Twitter;
                    aboutData.LinkedIn = model.LinkedIn;
                };
                db.SaveChanges();
                msg = "Update Successfully";
            }
            return msg;
        }

        public List<TeamModel> GetTeamList()
        {
            OrgSoftEntities db = new OrgSoftEntities();
            List<TeamModel> lstTeam = new List<TeamModel>();
            var Data = db.tblTeams.ToList();
            if (Data != null)
            {
                foreach (var item in Data)
                {
                    lstTeam.Add(new TeamModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Designation = item.Designation,
                        Photo = item.Photo,
                        Instagram = item.Instagram,
                        Facebook = item.Facebook,
                        Twitter = item.Twitter,
                        LinkedIn = item.LinkedIn

                    });
                }
            }
            return lstTeam;

        }

        public string DeleteTeam(int Id)
        {
            string msg = "";
            OrgSoftEntities db = new OrgSoftEntities();
            var Data = db.tblTeams.Where(p => p.Id == Id).FirstOrDefault();
            if (Data != null)
            {
                db.tblTeams.Remove(Data);
            };
            db.SaveChanges();
            msg = "Record deleted";
            return msg;
        }

        public TeamModel EditTeam(int Id)
        {
            string msg = "";
            TeamModel model = new TeamModel();
            OrgSoftEntities db = new OrgSoftEntities();
            var Data = db.tblTeams.Where(p => p.Id == Id).FirstOrDefault();
            if (Data != null)
            {
                model.Id = Data.Id;
                model.Name = Data.Name;
                model.Designation = Data.Designation;
                model.Photo = Data.Photo;
                model.Instagram = Data.Instagram;
                model.Facebook = Data.Facebook;
                model.Twitter = Data.Twitter;
                model.LinkedIn = Data.LinkedIn;
            };
            return model;
        }
    }
}
