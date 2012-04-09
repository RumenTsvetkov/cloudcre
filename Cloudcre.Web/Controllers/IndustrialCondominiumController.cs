﻿using System;
using System.Web.Mvc;
using Cloudcre.Infrastructure.CookieStorage;
using Cloudcre.Model;
using Cloudcre.Service.Property;
using Cloudcre.Service.Property.Messages;
using Cloudcre.Service.Property.ViewModels;
using Cloudcre.Web.Configuration;

namespace Cloudcre.Web.Controllers
{
    public class IndustrialCondominiumController : PropertyBaseController<IndustrialCondominium, Guid, IndustrialCondominiumViewModel>
    {
        private readonly IndustrialCondominiumService _service;

        public IndustrialCondominiumController(ICookieStorageService cookieStorageService, PropertyControllerConfigurationProvider configurationProvider, IndustrialCondominiumService service)
            : base(service, configurationProvider, cookieStorageService)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (configurationProvider == null)
                throw new ArgumentNullException("configurationProvider");

            _service = service;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new IndustrialCondominiumViewModel());
        }

        [HttpGet]
        public ActionResult Model(Guid? id)
        {
            if (ModelState.IsValid && id.HasValue)
            {
                GetPropertyResponse<IndustrialCondominiumViewModel> response = _service.GetProperty(new GetPropertyRequest<Guid> { Id = id.Value });

                return Json(response.ViewModel, JsonRequestBehavior.AllowGet);
            }

            return Json(new IndustrialCondominiumViewModel(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(Guid? id)
        {
            if (ModelState.IsValid && id.HasValue)
            {
                return View(new IndustrialCondominiumViewModel { Id = id.Value });
            }

            return View(new IndustrialCondominiumViewModel());
        }
    }
}