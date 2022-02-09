import React, { useEffect } from "react"
import { useState } from "react";
import { useHistory } from "react-router";
import { addCollection } from "../../modules/collectionManager";
import { addSneaker } from "../../modules/sneakerManager";
import { getLoggedInUser } from "../../modules/userManager";

export const SneakerForm = () => {

    const [user, setUser] = useState({});
    const [sneaker, setSneaker] = useState({
		name: "",
        brand: "",
        gender: "",
        colorway: "",
        releaseDate: "",
        retailPrice: 0,
        shoe: "",
        title: "",
        year: 0
	});

    const history = useHistory();

    const handleControlledInputChange = (event) => {
	
		const newSneaker = { ...sneaker }
		let selectedVal = event.target.value
		
		if (event.target.id.includes("Id")) {
			selectedVal = parseInt(selectedVal)
		}
	
		newSneaker[event.target.id] = selectedVal
		
		setSneaker(newSneaker)
	}

    const handleClickSaveTask = (event) => {
		event.preventDefault() 
        addSneaker(sneaker)
			.then(() => history.push("/"))
		}

        useEffect(() => {
            getLoggedInUser().then(user => setUser(user))
        }, []);

        if(user.userTypeId == 1){
    return (
        <>
<h2 className="salaryName">Add A New Sneaker</h2>


        <form className="salaryContainer">

            

            <fieldset className="">

                <div className="salaryFormContainer3">
                    <h2 className="salaryName">Sneaker Name</h2>
                </div>
                    <div className="formInput">
                        <input type="text" id="name" onChange={handleControlledInputChange} className="" placeholder="name" />
                    </div>
                    <div className="formInput">
                        <input type="text" id="brand" onChange={handleControlledInputChange} className="" placeholder="brand" />
                    </div>
                    <div className="formInput">
                        <input type="text" id="gender" onChange={handleControlledInputChange} className="" placeholder="gender" />
                    </div>
                    <div className="formInput">
                        <input type="text" id="colorway" onChange={handleControlledInputChange} className="" placeholder="colorway" />
                    </div>
                    <div className="formInput">
                        <input type="datetime-local" id="releaseDate" onChange={handleControlledInputChange} className="" placeholder="releaseDate" />
                    </div>
                    <div className="formInput">
                        <input type="number" id="retailPrice" onChange={handleControlledInputChange} className="" placeholder="retailPrice" />
                    </div>
                    <div className="formInput">
                        <input type="text" id="shoe" onChange={handleControlledInputChange} className="" placeholder="shoe" />
                    </div>
                    <div className="formInput">
                        <input type="text" id="title" onChange={handleControlledInputChange} className="" placeholder="title" />
                    </div>
                    <div className="formInput">
                        <input type="number" id="year" onChange={handleControlledInputChange} className="" placeholder="year" />
                    </div>
                <div className="salaryFormContainer2">
                <button className="budgetButton" onClick={handleClickSaveTask}>Create Shoe</button>
                <button className="budgetButton" onClick={() => history.push("/")}>Cancel</button>
            </div>
            </fieldset>
        </form>
        </>

    )} else {
        return 
        <>
            <div>
                <h2>Log in using an admin account to access this feature..</h2>
            </div>
        </>
    }
}