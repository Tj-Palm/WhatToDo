import Axios, {
    AxiosResponse,
    AxiosError
} from "../../node_modules/axios/index";

import {json2table100} from "./genericTable";

let BaseUri: string = "http://anbo-bookstorerest.azurewebsites.net/api/books"
let AllBooks: JSON;
let BaseUriA: string = "x"
let AllActivities: JSON;

interface IActivity {
    id: number,
    name: string,
    environment: string,
    activitylevel: string,
    time: number,
    weather: string
}

interface IBook {
    id: number,
    title: string,
    author: string,
    publisher: string,
    price: number,
 }

new Vue({
    el: "#App",
    data: {
        // activities: [],
        books: [],
        errors: [],
        deleteId: 0,
        deleteMessage: "",
        // formData: { name: "", environment: "", activitylevel: "", weather: "", time: 0 },
        formData: { title: "", author: "", publisher: "", price: 0 },
        addMessage: ""
    },
    created(){
        // this.getAllActivities(),
        // this.getAllActivitesJSON,
        this.getAllBooks(),
        this.getAllBooksJSON()
    },
    methods: {
        getAllActivities() {
            Axios.get<IActivity[]>(BaseUri + "activities") 
                .then((response: AxiosResponse<IActivity[]>) => {
                    this.activities = response.data
                    console.log("Activities then")
                })
                .catch((error: AxiosError) => {
                    console.log("Activities catch")
                    //this.message = error.message
                    alert(error.message) // https://www.w3schools.com/js/js_popup.asp
                })
        },
        getAllActivitesJSON() {
            Axios.get(BaseUri)
            .then((Response: AxiosResponse): void =>{
                console.log("Get books")
                let data: IActivity[] = Response.data;
                console.log(data)
                let result: string = json2table100(data)
                console.log(result)
            })
        },
        getAllBooks() {
            Axios.get<IBook[]>(BaseUri) 
                .then((response: AxiosResponse<IBook[]>) => {
                    this.books = response.data
                    console.log("Book then")
                })
                .catch((error: AxiosError) => {
                    //this.message = error.message
                    console.log("Book catch")
                    alert(error.message) // https://www.w3schools.com/js/js_popup.asp
                })
        },
        getAllBooksJSON() {
            Axios.get(BaseUri)
            .then((Response: AxiosResponse): void =>{
                console.log("Get books")
                let data: IBook[] = Response.data;
                console.log(data)
                let result: string = json2table100(data)
                console.log(result)
            })
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