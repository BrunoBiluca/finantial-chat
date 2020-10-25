export default function MessageItem(props) {

    function formattedDate(){
        let date = new Date(props.message.created_at)
        let fullDate = `${date.getFullYear()}-${date.getMonth()}-${date.getDate()}`

        let today = new Date(Date.now())
        let todayDate = `${today.getFullYear()}-${today.getMonth()}-${today.getDate()}`

        let formattedDate = ""
        if(todayDate > fullDate){
            formattedDate += fullDate
        }

        var hours = date.getHours();
        var minutes = "0" + date.getMinutes();
        formattedDate += ' ' + hours + ':' + minutes.substr(-2);

        return formattedDate;
    }

    return (
        <div className="message">
            <div style={{display: "flex", border: 0, margin: 0, padding: 0}}>
                <p style={{flex: 1}}>{props.message.user}</p>
                <p>{formattedDate()}</p>
            </div>
            <p>{props.message.message}</p>
        </div>
    )
}