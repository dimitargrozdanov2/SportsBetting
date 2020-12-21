
$(document).on("click", "td:nth-child(2)", function () {
    let oddValue = $(this).text().trim();
    let id = $(this).siblings().first().find(':input').val();
    let nameofOddProp = $(this).parent().parent().siblings().first().find('th:nth-child(2)').text().trim();
    console.log(`EventId: ${id}, name: ${nameofOddProp}, OddValue: ${oddValue}`);
});

$(document).on("click", "td:nth-child(3)", function () {
    let oddValue = $(this).text().trim();
    let id = $(this).siblings().first().find(':input').val();
    let nameofOddProp = $(this).parent().parent().siblings().first().find('th:nth-child(3)').text().trim();
    console.log(`EventId: ${id}, name: ${nameofOddProp}, OddValue: ${oddValue}`);
});

$(document).on("click", "td:nth-child(4)", function () {
    let oddValue = $(this).text().trim();
    let id = $(this).siblings().first().find(':input').val();
    let nameofOddProp = $(this).parent().parent().siblings().first().find('th:nth-child(4)').text().trim();
    console.log(`EventId: ${id}, name: ${nameofOddProp}, OddValue: ${oddValue}`);
});