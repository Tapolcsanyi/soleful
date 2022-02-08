import React, { useEffect, useState } from "react";
import ListSneakerCard from "./listSneaker";
import { deleteUserSneaker } from "../../modules/userSneakerManager";
import { deleteListSneaker, getListSneakerByListId } from "../../modules/listSneakerManager";
import { useParams } from "react-router-dom/cjs/react-router-dom.min";
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";

export const CollectionDetails = () => {
    const [sneakers, setSneakers] = useState([]);
    const { id } = useParams();

    const getSneakers = (id) => {
        getListSneakerByListId(id).then(setSneakers);
    }

    const handleDeleteSneaker = (listsneakerid) => {
        deleteListSneaker(listsneakerid).then(res => (
            getSneakers()
        ))
    }

    useEffect(() => {
        getSneakers(id);
    }, []);

    return (
        <> <div>
            <div>{sneakers.map(sneaker => <ListSneakerCard key={sneaker.id} sneaker={sneaker} handleDeleteSneaker={handleDeleteSneaker}/>)}</div>
        </div>
        </>
    )
}
export default CollectionDetails;