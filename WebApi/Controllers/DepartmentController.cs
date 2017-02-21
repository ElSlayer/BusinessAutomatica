namespace WebApi.Controllers
{
    using Model;
    using Model.Domain;
    // using Model.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class DepartmentController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            
            this._unitOfWork = unitOfWork;
        }

        // GET: api2/department
        public IEnumerable<Department> Get()
        {
            return this._unitOfWork.Departments.GetAll();
        }

        // POST: api2/department
        public IHttpActionResult Post([FromBody]Department value)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            try
            {
                this._unitOfWork.Departments.Add(value);
                this._unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                //#LOG
                return this.InternalServerError(ex);
            }

            return this.CreatedAtRoute("DepartmentApi", new { id = value.Id }, value);
        }

        // PUT: api2/department/5
        public IHttpActionResult Put(int id, [FromBody]Department value)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            Department department;
            try
            {
                department = this._unitOfWork.Departments.GetById(id);
                department.Title = value.Title;
                this._unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                //#LOG
                return this.InternalServerError(ex);
            }

            return this.Ok(department);
        }

        // DELETE: api2/department/5
        public IHttpActionResult Delete(int id)
        {
            var department = this._unitOfWork.Departments.GetById(id);
            if (department == null)
            {
                return this.NotFound();
            }

            try
            {
                // Think about moving this to some new method in IUserRepository, like GetUsersByDepartmentId
                IEnumerable<User> users = this._unitOfWork.Users.Find(u => u.DepartmentId == id);
                foreach (var user in users)
                {
                    this._unitOfWork.Users.Delete(user);
                }            
                this._unitOfWork.Departments.Delete(department);

                this._unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                //#LOG
                return this.InternalServerError(ex);
            }

            return this.Ok(department);
        }

        // GET: api2/department/5
        public IHttpActionResult Get(int id)
        {
            Department department;
            try
            {
                department = this._unitOfWork.Departments.GetById(id);
            }
            catch (Exception ex)
            {
                //#LOG
                return this.InternalServerError(ex);
            }

            if (department == null)
            {
                return this.NotFound();
            }

            return this.Ok(department);
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
