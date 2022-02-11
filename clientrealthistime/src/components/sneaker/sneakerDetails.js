import React from "react";
import { ListGroup, ListGroupItem, Button } from "reactstrap";
import { useEffect, useState } from "react";
import { getSneakerById } from "../../modules/sneakerManager";
import { useParams, useHistory } from "react-router-dom";
import { getAllUserCollection } from "../../modules/collectionManager";
import { addListSneaker } from "../../modules/listSneakerManager";
import '../sneaker/sneaker.css'

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
    return (
        <>
        <div  className="sneakerDetails">
        <div>
            <ListGroup className="listGroup">
                <ListGroupItem className="sneakerWords">
                    <h2>{sneaker.title}</h2>
                    <img src={sneaker.image}></img>
                </ListGroupItem>
                <ListGroupItem className="sneakerWords">
                    <h3>Color: {sneaker.colorway}</h3>
                    <h3>Release Year: {sneaker.year}</h3>
                    <h3>Sillhouette: {sneaker.shoe}</h3>
                </ListGroupItem>
            </ListGroup>
            <div className="listContainer">
            <div>
                <Button className="sneakerButton2" onClick={() => history.push("")} >Back to List</Button>
            </div>
            <div>
                <select className="dropdown" id="ListId" onChange={handleControlledInputChange}>
                    <option className="dropdown-content" selected disabled >Add to List</option>
                        {lists.map(list => <option className="dropdown-content" key={list.id} value={list.id}>{list.name}</option>)}
                </select>
            </div>
            <div>
                <Button className="sneakerButton2" onClick={handleClickSaveTask}>Add to List</Button>
            </div>
            </div>
        </div>
        </div>
        </>
    )
}
export default SneakerDetails;