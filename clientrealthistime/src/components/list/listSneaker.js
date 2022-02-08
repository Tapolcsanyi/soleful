import React from "react";
import { Link } from "react-router-dom";
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";
import { useState } from "react/cjs/react.development";
import { Card, CardBody, Button } from "reactstrap";
import { deleteUserSneaker } from "../../modules/userSneakerManager";

export const ListSneakerCard = ({ usneaker, handleDeleteSneaker }) => {

    return (
        <Card>
            <CardBody>
                <Link to={`/sneaker/${usneaker.sneakerId}`}>
                    <h3>{usneaker.sneaker.title}</h3>
                </Link>
            </CardBody>
            <CardBody>
                <p>{usneaker.sneaker.shoe}</p>
                <p>{usneaker.sneaker.name}</p>
            </CardBody>
            <Button onClick={() => handleDeleteSneaker(usneaker.id)}>Remove from List</Button>
        </Card>)
}

export default ListSneakerCard;