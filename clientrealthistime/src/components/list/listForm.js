import React, { useEffect } from "react"
import { useState } from "react";
import { useHistory } from "react-router";
import { addCollection } from "../../modules/collectionManager";

export const ListForm = () => {

    const [list, setList] = useState({
		name: ""
		
	});

    const history = useHistory();

    const handleControlledInputChange = (event) => {
	
		const newList = { ...list }
		let selectedVal = event.target.value
		
		if (event.target.id.includes("Id")) {
			selectedVal = parseInt(selectedVal)
		}
	
		newList[event.target.id] = selectedVal
		
		setList(newList)
	}

    const handleClickSaveTask = (event) => {
		event.preventDefault() 

	
			addCollection(list)
				.then(() => history.push("/lists"))
		}

    return (
        <>
<h2 className="salaryName">Add A New List</h2>


        <form className="salaryContainer">

            

            <fieldset className="">

                <div className="salaryFormContainer3">
                    <h2 className="salaryName">List Name</h2>
                </div>
                    <div className="formInput">
                        <input type="text" id="name" onChange={handleControlledInputChange} className="" placeholder="List" />
                    </div>
                <div className="salaryFormContainer2">
                <button className="budgetButton" onClick={handleClickSaveTask}>Create List</button>
                <button className="budgetButton" onClick={() => history.push("/")}>Cancel</button>
            </div>
            </fieldset>
        </form>
        </>

    )
}






