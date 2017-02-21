namespace WebApi.Controllers
{
    using Model;
    using Model.Domain;
    // using Model.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class UserController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            this._unitOfWork = unitOfWork;
        }

        // GET: api2/user
        public IEnumerable<User> Get()
        {
            return this._unitOfWork.Users.GetAll();
        }

        [Route()]
        public IEnumerable<User> GetAllByDepartmentId(int departmentId)
        {
            return this._unitOfWork.Users.Find(u => u.DepartmentId == departmentId);
        }

        // POST: api2/user
        public IHttpActionResult Post([FromBody]User value)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            try
            {
                this._unitOfWork.Users.Add(value);
                this._unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                //#LOG
                return this.InternalServerError(ex);
            }

            return this.CreatedAtRoute("UserApi", new { id = value.Id }, value);
        }

        // PUT: api2/user/5
        public IHttpActionResult Put(int id, [FromBody]User value)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            User user;
            try
            {
                user = this._unitOfWork.Users.GetById(id);
                user.UserName = value.UserName;
                this._unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                //#LOG
                return this.InternalServerError(ex);
            }

            return this.Ok(user);
        }

        // DELETE: api2/user/5
        public IHttpActionResult Delete(int id)
        {
            var user = this._unitOfWork.Users.GetById(id);
            if (user == null)
            {
                return this.NotFound();
            }

            try
            {
                this._unitOfWork.Users.Delete(user);
                this._unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                //#LOG
                return this.InternalServerError(ex);
            }

            return this.Ok(user);
        }

        // GET: api2/user/5
        public IHttpActionResult Get(int id)
        {
            User user;
            try
            {
                user = this._unitOfWork.Users.GetById(id);
            }
            catch (Exception ex)
            {
                //#LOG
                return this.InternalServerError(ex);
            }

            if (user == null)
            {
                return this.NotFound();
            }

            return this.Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
