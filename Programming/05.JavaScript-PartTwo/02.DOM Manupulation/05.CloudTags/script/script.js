var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css", "wordpress", "xaml", "js", "http", "web", "asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript", "http", "http", "CMS"];

function countTagsApearance(tagsToTraverse) {
    var tagsFounded = [];
    var tagsCount = [];
    var previousTag;

    tagsToTraverse.sort();
    for (var i = 0; i < tagsToTraverse.length; i++) {
        if (tagsToTraverse[i] !== previousTag) {
            tagsFounded.push(tagsToTraverse[i]);
            tagsCount.push(1);
        } else {
            tagsCount[tagsCount.length - 1]++;
        }
        previousTag = tagsToTraverse[i];
    }

    var result = [];
    for (var k = 0; k < tagsFounded.length; k++) {
        combined = {};
        combined.tag = tagsFounded[k];
        combined.count = tagsCount[k];
        result.push(combined);
    }

    return result;
}


function bubbleSort(tagsToTraverse) {
    var isSwapped;
    do {
        isSwapped = false;
        for (var i = 0; i < tagsToTraverse.length - 1; i++) {
            if (tagsToTraverse[i]["count"] > tagsToTraverse[i + 1]["count"]) {
                var currentElement = tagsToTraverse[i];
                tagsToTraverse[i] = tagsToTraverse[i + 1];
                tagsToTraverse[i + 1] = currentElement;
                isSwapped = true;
            }
        }
    } while (isSwapped);
    return tagsToTraverse;
}

var filteredTags = countTagsApearance(tags);
var sortedFilteredTags = bubbleSort(filteredTags);

for (var j = 0; j < sortedFilteredTags; j++) {
    
}