// returns formated time and date
function getFormattedDateTime(format) {
    var date = new Date
    return Qt.formatDateTime(date, format)
}
