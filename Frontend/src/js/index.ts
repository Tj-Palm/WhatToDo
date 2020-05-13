import Axios, {
    AxiosResponse,
    AxiosError
} from "../../node_modules/axios/index";

import { json2table100 } from "./genericTable";

let BaseUri: string = "http://whattodorest.azurewebsites.net/api"
let AllActivitiesUri: string = "/activities"
let RandomActivityUri: string = "/random"
let AllActivities: JSON;

interface IActivity {
    id: number,
    name: string,
    environment: string,
    activityLevel: string,
    timeInterval: number,
    weather: string
}

interface Coord {
    lon: number;
    lat: number;
}

interface Weather {
    id: number;
    main: string;
    description: string;
    icon: string;
}

interface Main {
    temp: number;
    feels_like: number;
    temp_min: number;
    temp_max: number;
    pressure: number;
    humidity: number;
}

interface Wind {
    speed: number;
    deg: number;
}

interface Clouds {
    all: number;
}

interface Sys {
    type: number;
    id: number;
    country: string;
    sunrise: number;
    sunset: number;
}

interface WeatherObject {
    coord: Coord;
    weather: Weather[];
    base: string;
    main: Main;
    visibility: number;
    wind: Wind;
    clouds: Clouds;
    dt: number;
    sys: Sys;
    timezone: number;
    id: number;
    name: string;
    cod: number;
}

new Vue({
    el: "#App",
    data: {
        activities: [],
        errors: [],
        //deleteId: 0,
        //deleteMessage: "",
        //formData: { name: "", environment: "", activityLevel: "", weather: "", timeInterval: 0 },
        //addMessage: "",
        switch1: true,
        switch2: true,
        result: "",
        activeresult: false,
        TimeInterval: 10,
        ShowEnvironmentButton: true,
        GetWeatherTimestamp: 0,
    },

    created() {
        this.getAllActivities()
            //this.getAllActivitesJSON()
    },

    methods: {
        getWeatherData() {
            if (this.GetWeatherTimestamp == 0 || this.GetWeatherTimestamp + 60000 < Date.now()) {
                this.GetWeatherTimestamp = Date.now();
                Axios.get<WeatherObject>("http://api.openweathermap.org/data/2.5/weather?q=Roskilde,dk&APPID=622f66a99c7a179b5c667c2d504ac522&units=metric")
                    .then((response: AxiosResponse<WeatherObject>) => {
                        let weather = response.data;
                        if (weather.main.feels_like < 5) {
                            this.ShowEnvironmentButton = false;
                        }
                        
                        if (weather.weather[0].id != 800 && weather.weather[0].id != 801 && weather.weather[0].id != 802) {
                            this.ShowEnvironmentButton = false;
                        }
                    })
            }
            else {
                console.log("Not allowed to get weather now")
            }
        },

        getAllActivities() {
            Axios.get<IActivity[]>(BaseUri + AllActivitiesUri)
                .then((response: AxiosResponse<IActivity[]>) => {
                    this.activities = response.data
                    console.log("Activities then")
                    console.log(response.data)
                })
                .catch((error: AxiosError) => {
                    console.log("Activities catch")
                    //this.message = error.message
                    alert(error.message) // https://www.w3schools.com/js/js_popup.asp
                })
        },
        // getAllActivitesJSON() {
        //     Axios.get(BaseUri + AllActivitiesUri)
        //         .then((Response: AxiosResponse): void => {
        //             console.log("Get books")
        //             let data: IActivity[] = Response.data;
        //             console.log(data)
        //             let result: string = json2table100(data)
        //             console.log(result)
        //         })
        // },
        RandomActivity() {
            let ActivityLevel: string
            let Environment: string
            this.result = "";

            if (this.switch1) {
                ActivityLevel = "SpareTime"
            }
            else {
                ActivityLevel = "Work"
            }

            if (this.switch2) {
                Environment = "Indoor"
            }
            else {
                Environment = "Outdoor"
            }
            console.log(this.TimeInterval)

            Axios.get(BaseUri + AllActivitiesUri + RandomActivityUri + "/?ActivityLevel=" + ActivityLevel + "&Environment=" + Environment + "&TimeInterval=" + this.TimeInterval)
                .then((Response: AxiosResponse): void => {
                    let data: string = Response.data.name
                    this.result = data
                    console.log(Response.data)
                })
                .catch((Error: AxiosError): void => {
                    this.result = "Det er ingen Aktiviteter lige nu!!"

                })


            this.activeresult = true;
            console.log(this.TimeInterval)
        }
        // deleteActivity(deleteId: number) {
        //     let uri: string = BaseUri + "activities" + "/" + deleteId
        //     Axios.delete<void>(uri)
        //         .then((response: AxiosResponse<void>) => {
        //             this.deleteMessage = "Activity Deleted"
        //             this.getAllActivities()
        //         })
        //         .catch((error: AxiosError) => {
        //             //this.deleteMessage = error.message
        //             alert(error.message)
        //         })
        // },
        // addActivity() {
        //     let name : HTMLInputElement = <HTMLInputElement> document.getElementById("inputname");
        //     let type : HTMLInputElement = <HTMLInputElement> document.getElementById("inputtype");
        //     let weather : HTMLInputElement = <HTMLInputElement> document.getElementById("inputweather");
        //     let time : HTMLInputElement = <HTMLInputElement> document.getElementById("inputtime");

        //     Axios.post<IActivity>(BaseUri + "activities", this.formData)
        //         .then((response: AxiosResponse) => {
        //             let message: string = "Activity Added"
        //             this.addMessage = message
        //             this.getAllActivities()
        //         })
        //         .catch((error: AxiosError) => {
        //             // this.addMessage = error.message
        //             alert(error.message)
        //         })
        // }

    }
})