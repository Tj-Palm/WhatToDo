import Axios, {
    AxiosResponse,
    AxiosError
} from "../../node_modules/axios/index";

import {json2table100} from "./genericTable";

let BaseUri: string = "http://whattodorest.azurewebsites.net/api/activities"
let AllActivities: JSON;

interface IActivity {
    id: number,
    name: string,
    environment: string,
    activityLevel: string,
    timeUsage: number,
    weather: string
}



new Vue({
    el: "#App",
    data: {
        activities: [],
        errors: [],
        //deleteId: 0,
        //deleteMessage: "",
        //formData: { name: "", environment: "", activityLevel: "", weather: "", timeUsage: 0 },
        //addMessage: "",
        switch1: true,
        switch2: true,
        result: "pfejgwpjfepofeq",
        activeresult: false,
    },
    created(){
        this.getAllActivities(),
        this.getAllActivitesJSON()
    },
    methods: {
        getAllActivities() {
            Axios.get<IActivity[]>(BaseUri) 
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
        RandomActivity(){
            odoo.default({ el:'.js-odoo', from: 'ThingToDo', to: 'CODEVEMBER', animationDelay: 1000 });
            this.activeresult = true;
            
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