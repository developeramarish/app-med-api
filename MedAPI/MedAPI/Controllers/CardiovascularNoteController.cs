﻿using MedAPI.Domain;
using MedAPI.Infrastructure.IService;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/CardiovascularNote")]
    public class CardiovascularNoteController : ApiController
    {
        private readonly ICardiovascularNoteService cardiovascularNoteService;
        private readonly IUserService userService;

        public CardiovascularNoteController(ICardiovascularNoteService cardiovascularNoteService, IUserService userService)
        {
            this.cardiovascularNoteService = cardiovascularNoteService;
            this.userService = userService;
        }

        [HttpGet]
        [Route("List")]
        public HttpResponseMessage List()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, cardiovascularNoteService.GetAllCardiovascularNote());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Show/{id:int}")]
        public HttpResponseMessage Show(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                CardiovascularNote mCardiovascularNote = cardiovascularNoteService.GetCardiovascularNoteById(id);
                if (mCardiovascularNote == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, mCardiovascularNote);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("Delete/{id:int}")]
        public HttpResponseMessage Delete(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                bool isSuccess = false;
                isSuccess = cardiovascularNoteService.DeleteCardiovascularNoteById(id);
                if (isSuccess)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, "Entity removed successfully.");
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;

        }

        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(CardiovascularNote mCardiovascularNote)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                     int id = cardiovascularNoteService.SaveCardiovascularNote(mCardiovascularNote);

                        if (id > 0)
                        {
                            response = Request.CreateResponse(HttpStatusCode.OK, id);
                        }
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.Unauthorized);
                }

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("Update")]
        public HttpResponseMessage Update(CardiovascularNote mCardiovascularNote)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    int id = cardiovascularNoteService.SaveCardiovascularNote(mCardiovascularNote);

                    if (id > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, id);
                    }
                }
                else
                    response = Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        public bool IsAdminPermission()
        {
            bool result = false;
            var headerValues = HttpContext.Current.Request.Headers.GetValues("email");
            string email = Convert.ToString(headerValues.FirstOrDefault());
            var user = userService.GetByEmail(email);
            if (user != null)
            {
                if (user.RoleId == (int)Infrastructure.Common.Permission.ADMIN)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
