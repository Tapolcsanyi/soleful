import React, { useState, useEffect } from "react";
import { useParams, useHistory } from "react-router-dom";
import { getCollectionById, updateCollection, updateTag } from "../../modules/collectionManager";


export const ListUpdateForm = () => {
    const [list, setList] = useState({ name: "" });

    const { id } = useParams();
    const history = useHistory();


    useEffect((event) => {
        getCollectionById(id).then((res) => {
            setList(res);
        });
    }, []);

    const handleControlledInputChange = (event) => {
        const newList = { ...list };
        let selectedVal = event.target.value;

        newList[event.target.id] = selectedVal;
        // update state
        setList(newList);
    };

    const handleConfirm = (event) => {
        event.preventDefault();

        updateCollection(list).then(() => history.push("/lists"));
    };
    return (
        <>
        <div className="listInput">
            <form>
                <fieldset>
                <div>
                    <h3>Edit List</h3>
                    <label className="list-name" htmlFor="name">List Name</label> <input
                        type="text"
                        required
                        className="form-control"
                        onChange={handleControlledInputChange}
                        id="name"
                        value={list.name} />
                </div>
                    <button
                        type="button"
                        onClick={handleConfirm}
                        className="sneakerButton2"
                    >Save</button>
                <button
                    className="sneakerButton2"
                    variant="secondary"
                    onClick={() => history.push("/lists")}>
                    Cancel
                </button>
            </fieldset>
            </form>
        </div>
        </>
    );
}
export default ListUpdateForm;