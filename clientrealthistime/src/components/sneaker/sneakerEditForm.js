import React, { useState, useEffect } from "react";
import { useParams, useHistory } from "react-router-dom";
import { getCollectionById, updateCollection, updateTag } from "../../modules/collectionManager";
import { getSneakerById, updateSneaker } from "../../modules/sneakerManager";


export const SneakerUpdateForm = () => {
    const [sneaker, setSneaker] = useState({
        name: "",
        brand: "",
        gender: "",
        colorway: "",
        releaseDate: "",
        retailPrice: 0,
        shoe: "",
        title: "",
        year: 0,
        image: ""
    });

    const { id } = useParams();
    const history = useHistory();


    useEffect((event) => {
        getSneakerById(id).then((res) => {
            setSneaker(res);
        });
    }, []);

    const handleControlledInputChange = (event) => {
        const newSneaker = { ...sneaker };
        let selectedVal = event.target.value;

        newSneaker[event.target.id] = selectedVal;
        // update state
        setSneaker(newSneaker);
    };

    const handleConfirm = (event) => {
        event.preventDefault();

        updateSneaker(sneaker).then(() => history.push("/"));
    };

    return (
        <>
            <form>
            <h3>Edit Sneaker</h3>
                <div>
                    <label className="sneaker-name" htmlFor="name">Sneaker Title</label>
                    <input type="text" required className="form-control" onChange={handleControlledInputChange} id="title" value={sneaker.title} />
                </div>
                <div>
                    <label className="sneaker-name" htmlFor="name">Sneaker Name</label>
                    <input type="text" required className="form-control" onChange={handleControlledInputChange} id="name" value={sneaker.name} />
                </div>
                <div>
                    <label className="sneaker-name" htmlFor="name">Sneaker Brand</label>
                    <input type="text" required className="form-control" onChange={handleControlledInputChange} id="brand" value={sneaker.brand} />
                </div>
                <div>
                    <label className="sneaker-name" htmlFor="name">Sneaker Gender</label>
                    <input type="text" required className="form-control" onChange={handleControlledInputChange} id="gender" value={sneaker.gender} />
                </div>
                <div>
                    <label className="sneaker-name" htmlFor="name">Sneaker Colorway</label>
                    <input type="text" required className="form-control" onChange={handleControlledInputChange} id="colorway" value={sneaker.colorway} />
                </div>
                <div>
                    <label className="sneaker-name" htmlFor="name">Sneaker Release Date</label>
                    <input type="datetime-local" required className="form-control" onChange={handleControlledInputChange} id="releaseDate" value={sneaker.releaseDate} />
                </div>
                <div>
                    <label className="sneaker-name" htmlFor="name">Sneaker Retail Price</label>
                    <input type="number" required className="form-control" onChange={handleControlledInputChange} id="retailPrice" value={sneaker.retailPrice} />
                </div>
                <div>
                    <label className="sneaker-name" htmlFor="name">Sneaker Shoe</label>
                    <input type="text" required className="form-control" onChange={handleControlledInputChange} id="shoe" value={sneaker.shoe} />
                </div>
                <div>
                    <label className="sneaker-name" htmlFor="name">Sneaker Year</label>
                    <input type="number" required className="form-control" onChange={handleControlledInputChange} id="year" value={sneaker.year} />
                </div>
                <div>
                    <label className="sneaker-name" htmlFor="name">Sneaker Image URL</label>
                    <input type="text" required className="form-control" onChange={handleControlledInputChange} id="image" value={sneaker.image} />
                </div>
                <div className="alignRight">
                    <button type="button" onClick={handleConfirm} className="list_button">Save</button>
                </div>
                <button className="btn-add-edit" variant="secondary" onClick={() => history.push("/")}>Cancel</button>
            </form>
        </>
    );
}
export default SneakerUpdateForm;