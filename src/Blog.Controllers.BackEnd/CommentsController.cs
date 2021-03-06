﻿namespace Blog.Controllers.BackEnd
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Base;
    using Blog.Services.Comment.Models;
    using Data.Base.Extensions;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Services.Comment;
    using ViewModels.BackEnd.Comments;

    [Area("Admin")]
    public class CommentsController : BackEndController
    {
        private readonly ICommentService _commentService;

        public CommentsController(
            ICommentService commentService,
            ILogger<BackEndController> logger,
            IMapper mapper) : base(logger, mapper)
        {
            _commentService = commentService;
        }

        public IActionResult Index(int page = 1)
        {
            var viewModel = _commentService.GetAll()
                .To<CommentViewModel>()
                .GetPaged(page, MaxPageSize);

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(Guid id)
        {          
            var commentViewModel = await GetCommentViewModel(id);

            return View(commentViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _commentService.DeleteComment(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
             var comment = await _commentService.GetById(id);

            if(comment == null)
            {
                return NotFound();
            }

            var commentViewModel = Mapper.Map<EditCommentViewModel>(comment);

            return View(commentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCommentViewModel viewModel)
        {
            var editCommentServiceModel = Mapper.Map<EditCommentServiceModel>(viewModel);

            await _commentService.Edit(editCommentServiceModel);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(Guid id)
        {           
            var commentViewModel = await GetCommentViewModel(id);

            return View(commentViewModel);
        }

        private async Task<CommentViewModel?> GetCommentViewModel(Guid id)
        {
            var comment = await _commentService.GetById(id);

            if(comment == null)
            {
                return null;
            }

            var commentViewModel = Mapper.Map<CommentViewModel>(comment);

            return commentViewModel;
        }
    }
}
