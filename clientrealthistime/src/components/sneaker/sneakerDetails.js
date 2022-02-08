import React from "react";
import { ListGroup, ListGroupItem, Button } from "reactstrap";
import { useEffect, useState } from "react";
import { getSneakerById } from "../../modules/sneakerManager";
import { useParams, useHistory } from "react-router-dom";
import { getAllUserCollection } from "../../modules/collectionManager";
import { addListSneaker } from "../../modules/listSneakerManager";


export const SneakerDetails = () => {

    const { id } = useParams();
    
    const history = useHistory();
    const [lists, setLists] = useState([])
    const [listSneaker, setListSneaker] = useState({
		SneakerId: id,
		ListId: 0
		
	});
    const [sneaker, setSneaker] = useState([]);

    const getSneaker = (id) => {
        getSneakerById(id).then(setSneaker);
    }

    const getLists = () => {
        return getAllUserCollection().then(res => {
            setLists(res)
        })
    }

    const handleControlledInputChange = (event) => {
	
		const newListSneaker = { ...listSneaker }
		let selectedVal = event.target.value
		
		if (event.target.id.includes("Id")) {
			selectedVal = parseInt(selectedVal)
		}
	
		newListSneaker[event.target.id] = selectedVal
		
		setListSneaker(newListSneaker)
        console.log(newListSneaker)
	}

    useEffect(() => {
        getSneaker(id);
        getLists();
    }, []);

    const handleClickSaveTask = (event) => {
		event.preventDefault() 
        addListSneaker(listSneaker)
        console.log(listSneaker)
    }
        if (!sneaker.title) {
        return null;
    }
    return (
        <>
            <ListGroup>
                <ListGroupItem>
                    <h3>{sneaker.title}</h3>
                </ListGroupItem>
                <ListGroupItem>
                    <p>{sneaker.colorway}</p>
                </ListGroupItem>
                <ListGroupItem>
                    <p>{sneaker.year}</p>
                    <p>Sillhouette: {sneaker.shoe}</p>
                    <p>Category: {sneaker.name}</p>
                </ListGroupItem>
            </ListGroup>
            <div>
                <Button onClick={() => history.push("")} >Back to List</Button>
            </div>
            <div>
                <select className="" id="ListId" onChange={handleControlledInputChange}>
                    <option defaultValue={"0"} disabled >Add to List</option>
                        {lists.map(list => <option key={list.id} value={list.id}>{list.name}</option>)}
                </select>
            </div>
            <div>
                <Button onClick={handleClickSaveTask}>Add to List</Button>
            </div>
        </>
    )
}
export default SneakerDetails;