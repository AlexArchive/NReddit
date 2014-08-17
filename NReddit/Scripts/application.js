$(document).ready(function() {
    $(document).on('click', '.upvote-link', vote);
    $(window).bind('mousewheel DOMMouseScroll', appendPosts);
});


var authenticated = false;

function vote() {
    if (!authenticated) {
        alert('You must be authenticated before you can vote. Please login.');
        return;
    }

    var voteButton = $(this);
    var postId = voteButton.attr('data-id');
    var voted = voteButton.hasClass('voted');
    var voteCountLabel = voteButton.next('.vote-count');
    
    if (voted) {
        voteButton.removeClass('voted');
        voteCountLabel.text(parseInt(voteCountLabel.text(), 10) - 1);
    } else {
        voteButton.addClass('voted');
        voteCountLabel.text(parseInt(voteCountLabel.text(), 10) + 1);
    }

    $.get('Home/Vote/' + postId, function(response) {
        if (!response.Success) {
            alert(response.Message);
        }
    })
    .fail(function(error) {

    });
}

var count = 1;
var loading = false;
var finished = false;

function appendPosts() {
    var bottom = $(window).scrollTop() == $(document).height() - $(window).height();
    if (!bottom || loading || finished)  return;
    
    loading = true;
    $('#loadingAnimation').show();

    $.get('Home/InfiniteScroll/' + count, function(response) {
        $('#loadingAnimation').hide();
        loading = false;

        count++;

        $('#postTemplate')
            .tmpl(response.Posts)
            .appendTo('.posts');

        if (response.Finished) {
            finished = true;
        }

    })
    .fail(function(error) {
    
    });
}