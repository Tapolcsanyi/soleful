import React from "react";
import { Link } from "react-router-dom";
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";
import { useState } from "react/cjs/react.development";
import { Card, CardBody, Button } from "reactstrap";
import { deleteUserSneaker } from "../../modules/userSneakerManager";

export const ListSneakerCard = ({ usneaker, handleDeleteSneaker }) => {

    const history = useHistory();

    return (
        <div className="">
        <Card className="cardBody">
            <CardBody>
            <img className="sneakerImg" src={usneaker.sneaker.image}></img>
            <Link to={`/sneaker/${usneaker.sneakerId}`}>
                    <h3>{usneaker.sneaker.title}</h3>
                </Link>
                <h3>Retail Price: ${usneaker.sneaker.retailPrice}</h3>
                <Button className="sneakerButton" onClick={() => handleDeleteSneaker(usneaker.id)}>Remove from Collection</Button>
            </CardBody>
        </Card>
        </div>)
}

export default ListSneakerCard;