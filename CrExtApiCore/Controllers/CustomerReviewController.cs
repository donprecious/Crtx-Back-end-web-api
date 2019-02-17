using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using CrExtApiCore.Models;
using CrExtApiCore.Repositories;
using AutoMapper;
using Entities;

namespace CrExtApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Review")]
    [EnableCors("AllowOrigin")]
    public class CustomerReviewController : Controller
    {
        private IReviewNotification _reviewNotification;
        private IReview _review;
        private IReviewAction _reviewAction;
        private IReviewKind _reviewKind;

        public CustomerReviewController(IReviewNotification reviewNotification, IReview review, IReviewAction reviewAction, IReviewKind reviewKind)
        {
            _review = review;
            _reviewNotification = reviewNotification;
            _reviewAction = reviewAction;
            _reviewKind = reviewKind;
        }

        [HttpGet("GetReview/{id}", Name = "GetReview")]
        public async Task<IActionResult> GetReview(int id)
        {
            if (!await _reviewNotification.Find(id)) return NotFound("Customer not Found");
            var review = await _reviewNotification.Get(id);
            return Ok(review);
        }

        [HttpGet("GetReviewKind")]
        public async Task<IActionResult> GetReviewKind()
        {   
            var review = await _reviewKind.List();
            return Ok(review);
        }

        [HttpGet("GetReviewAction")]
        public async Task<IActionResult> GetReviewAction()
        {
            var review = await _reviewAction.List();
            return Ok(review);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateReviewAndNotitficationDto reviewAndNotificationDto)
        {
            if (reviewAndNotificationDto == null) return NotFound();

            if (ModelState.IsValid)
            {
                var reviewCreateMapped = new CreateReviewDto {
                    Comment = reviewAndNotificationDto.review.Comment,
                    CustomerId= reviewAndNotificationDto.review.CustomerId,
                    TeamMemberId = reviewAndNotificationDto.review.TeamMemberId
                };

                var reviewNotificationCreateMapped = new CreateReviewNotificationsDto
                {
                    ReviewActionId = reviewAndNotificationDto.reviewNotification.ReviewActionId,
                    ReviewKindId = reviewAndNotificationDto.reviewNotification.ReviewKindId,
                    StartDate = reviewAndNotificationDto.reviewNotification.StartDate,
                    EndDate = reviewAndNotificationDto.reviewNotification.EndDate,
                    DateAdded = DateTime.UtcNow
                };
               
                //var reviewMapped = Mapper.Map<CreateReviewDto>(reviewAndNotificationDto);
                //var notificationMapped = Mapper.Map<CreateReviewNotificationsDto>(reviewAndNotificationDto);

                // var targetReview = Mapper.Map<Reviews>(reviewMapped);
                var targetReview = Mapper.Map<Reviews>(reviewCreateMapped);

                await _review.Create(targetReview);
                //
                if (!await _review.Save())
                {                  
                    return StatusCode(500, "Server Error, Something went wrong with our server");
                }
                var createdReview = Mapper.Map<Reviews>(targetReview);

                //notificationMapped.ReviewId = createdReview.Id;
                reviewNotificationCreateMapped.ReviewId = createdReview.Id;
                // var targetNotification = Mapper.Map<ReviewNotifications>(notificationMapped);
                var targetNotification = Mapper.Map<ReviewNotifications>(reviewNotificationCreateMapped);

                await _reviewNotification.Create(targetNotification);

                if(!await _review.Save())
                {
                    return StatusCode(500, "Server Error, Something went wrong with our server");
                }

                var createdNotification = Mapper.Map<ReviewNotifications>(targetNotification);
               return CreatedAtRoute("GetReview", new {id = createdNotification.Id }, createdNotification);
                //return CreatedA("/GetReview/"+  createdNotification.Id, createdNotification);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}