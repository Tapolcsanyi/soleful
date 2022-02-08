import React from "react";
import { Link } from "react-router-dom";
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";
import { useState } from "react/cjs/react.development";
import { Card, CardBody, Button } from "reactstrap";

export const CollectionCard = ({ collection, handleDeleteCollection }) => {

    const history = useHistory();

    const handleEditList = () => {
        history.push(`/listeditform/${collection.id}`);
    };

    return (
        <Card>
            <CardBody>
                <Link to={`/lists/${collection.id}`}>
                    <h3>{collection.name}</h3>
                </Link>
            </CardBody>
            <Button onClick={() => handleEditList(collection.id)}>Edit List</Button>
            <Button onClick={() => handleDeleteCollection(collection.id)}>Delete List</Button>
        </Card>)
}

export default CollectionCard;