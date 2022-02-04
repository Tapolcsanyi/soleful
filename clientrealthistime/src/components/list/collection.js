import React from "react";
import { Link } from "react-router-dom";
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";
import { useState } from "react/cjs/react.development";
import { Card, CardBody, Button } from "reactstrap";
import { deleteUserSneaker } from "../../modules/userSneakerManager";

export const CollectionCard = ({ collection, handleDeleteCollection }) => {

    return (
        <Card>
            <CardBody>
                <Link to={`/collection/${collection.id}`}>
                    <h3>{collection.name}</h3>
                </Link>
            </CardBody>
            <Button onClick={() => handleDeleteSneaker(usneaker.id)}>Remove from Collection</Button>
        </Card>)
}

export default UserSneakerCard;