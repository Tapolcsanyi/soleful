import React, { useEffect, useState } from "react";
import { CollectionCard } from "./collection";
import { deleteCollection, getAllUserCollection } from "../../modules/collectionManager";
import { Button } from "reactstrap";
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";
import '../sneaker/sneaker.css'

export const CollectionList = () => {
    const [collections, setCollections] = useState([]);

    const history = useHistory();

    const getCollections = () => {
        return getAllUserCollection().then(collections => {
            setCollections(collections)
        });
    };

    const handleDeleteCollection = (collectionId) => {
        deleteCollection(collectionId).then(res => (
            getCollections()
            .then (res =>
                console.log(res))
        ))
    }

    useEffect(() => {
        getCollections();
    }, []);

    return (
        <> 
            <div>
                <Button className="sneakerButton2" onClick={() => history.push("/listform")}>Create a List</Button>
            </div>
            <div>
                <div className="cardList" >{collections.map(collection => <CollectionCard key={collection.id} collection={collection} handleDeleteCollection={handleDeleteCollection}/>)}</div>
            </div>
        </>
    )
}
export default CollectionList;