﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultipleRanker.Contracts;
using MultipleRanker.Contracts.Messages;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Host.Controllers
{
    [Route("api/[controller]")]
    public class RatingBoardController : Controller
    {
        private readonly IMessagePublisher _messagePublisher;
        private readonly IRatingsRepository _ratingsRepository;

        public RatingBoardController(
            IMessagePublisher messagePublisher,
            IRatingsRepository ratingsRepository)
        {
            _messagePublisher = messagePublisher;
            _ratingsRepository = ratingsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRatingBoard(
            [FromQuery(Name = "id")] Guid id,
            [FromQuery(Name = "name")] string name)
        {
            var correlationId = Guid.NewGuid();

            var createRatingBoard = new CreateRatingBoard
            {
                Id = id,
                Name = name
            };

            _messagePublisher.Publish(createRatingBoard, correlationId);

            return Created(new Uri("http://www.google.com"), null);
        }

        [HttpPost]
        public async Task<IActionResult> AddParticipantToRatingBoard(
            [FromQuery(Name = "ratingBoardId")] Guid ratingBoardId,
            [FromQuery(Name = "participantId")] Guid participantId,
            [FromQuery(Name = "participantName")] string participantName
            )
        {
            var correlationId = Guid.NewGuid();

            var addParticipantToRatingBoard = new AddParticipantToRatingBoard
            {
                RankingBoardId = ratingBoardId,
                ParticipantId = participantId,
                ParticipantName = participantName
            };

            _messagePublisher.Publish(addParticipantToRatingBoard, correlationId);

            return Created(new Uri("http://www.google.com"), null);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateRatingsForRatingBoard(
            [FromQuery(Name = "ratingBoardId")] Guid ratingBoardId)
        {
            var correlationId = Guid.NewGuid();

            var generateRatingsForRatingBoard = new GenerateRatingsForRatingBoard
            {
                RatingBoardId = ratingBoardId,
                RatingType = RatingType.OffensiveDefensive,
            };

            _messagePublisher.Publish(generateRatingsForRatingBoard, correlationId);

            return Created(new Uri("http://www.google.com"), null);
        }

        [HttpGet]
        public async Task<IActionResult> GetLatestRatings(
            [FromQuery(Name = "ratingBoardId")] Guid ratingBoardId)
        {
            return Ok(await _ratingsRepository.GetLatestRating(ratingBoardId));
        }

        [HttpGet]
        public async Task<IActionResult> GetRatings(
            [FromQuery(Name = "ratingBoardId")] Guid ratingBoardId)
        {
            return Ok(await _ratingsRepository.GetAllRatings(ratingBoardId));
        }
    }
}