using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.Data.Entity.Validation;

namespace Model.Dao
{
    public class UserDao
    {
        OnlineClassContext db = null;

        public UserDao()
        {
            db = new OnlineClassContext();
        }

        // Thêm vào cơ sở dũ liệu
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return entity.ID;
        }

        // Cập nhật dữ liệu
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Name = entity.Name;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Xóa
        public bool Delete(long id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // trả về danh sách tất cả người dùng
        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            // Sắp sếp theo thứ tự ngày tạo
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }


        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }

        public User ViewDetail(long id)
        {
            return db.Users.Find(id);
        }

        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }

        public bool ChangeAdmin(long id)
        {
            var user = db.Users.Find(id);
            user.Quyen = !user.Quyen;
            db.SaveChanges();
            return user.Quyen;
        }

        public int Login(string userName, string password)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            //var result = (from x in db.Users where (x.UserName == userName && x.Password == password) select x).Count();
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Quyen == false)
                {
                    return -3;
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == password)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }

        public int LoginUser(string userName, string password)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            //var result = (from x in db.Users where (x.UserName == userName && x.Password == password) select x).Count();
            if (result == null)
            {
                return 0;
            }
            else
            {

                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == password)
                        return 1;
                    else
                        return -2;
                }

            }
        }

        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.UserName == userName) > 0;
        }

        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }

        public string GetEmail(string userName)
        {
            string email = (from cust in db.Users
                         where cust.UserName == userName
                         select cust.Email).FirstOrDefault();
            return email;
        }
    }
}
