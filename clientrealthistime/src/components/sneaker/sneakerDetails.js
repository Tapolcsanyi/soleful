import React from "react";
import { ListGroup, ListGroupItem, Button } from "reactstrap";
import { useEffect, useState } from "react";
import { getSneakerById } from "../../modules/sneakerManager";
import { useParams, useHistory } from "react-router-dom";


export const SneakerDetails = () => {

    const history = useHistory();
    const [sneaker, setSneaker] = useState([]);
    const { id } = useParams();

    const getSneaker = (id) => {
        getSneakerById(id).then(setSneaker);
    }

    useEffect(() => {
        getSneaker(id);
    }, []);

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
                <Button onClick={() => history.push(`/comment/${id}`)}>View Comments</Button>
                <Button onClick={() => history.push(`/comment/${id}/create`)} >Add Comment</Button>
                <Button onClick={() => history.push("")} >Back to List</Button>

            </div>
        </>
    )
}
export default SneakerDetails;