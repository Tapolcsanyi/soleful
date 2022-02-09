import React, { useEffect, useState } from "react";
import ListSneakerCard from "./listSneaker";
import { deleteUserSneaker } from "../../modules/userSneakerManager";
import { deleteListSneaker, getListSneakerByListId } from "../../modules/listSneakerManager";
import { useParams } from "react-router-dom/cjs/react-router-dom.min";
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";

export const CollectionDetails = () => {
    const [sneakers, setSneakers] = useState([]);
    const { id } = useParams();

    const getSneakers = () => {
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
            <div>{sneakers.map(usneaker => <ListSneakerCard key={usneaker.id} usneaker={usneaker} handleDeleteSneaker={handleDeleteSneaker}/>)}</div>
        </div>
        </>
    )
}
export default CollectionDetails;