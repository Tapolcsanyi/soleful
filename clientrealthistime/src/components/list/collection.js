import React from "react";
import { Link } from "react-router-dom";
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";
import { useState } from "react/cjs/react.development";
import { Card, CardBody, Button } from "reactstrap";
import '../sneaker/sneaker.css'

export const CollectionCard = ({ collection, handleDeleteCollection }) => {

    const history = useHistory();

    const handleEditList = () => {
        history.push(`/listeditform/${collection.id}`);
    };

    return (
        <div className="cardBody2">
        <Card className="">
            <CardBody>
                <Link to={`/lists/${collection.id}`}>
                    <h3>{collection.name}</h3>
                </Link>
            </CardBody>
            <div className="buttonContainer">
            <Button className="sneakerButton2" onClick={() => handleEditList(collection.id)}>Edit List</Button>
            <Button className="sneakerButton2" onClick={() => handleDeleteCollection(collection.id)}>Delete List</Button>
            </div>
        </Card>
        </div>)
}

export default CollectionCard;