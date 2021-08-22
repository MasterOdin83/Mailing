export default function UserList({ lastName, firstname, userEmail }) {
    return (
        <div className="row">
            <div className="col-3">
                <p className="text-white-50">{lastName}</p>
            </div>
            <div className="col-3">
                <p className="text-white-50">{firstname}</p>
            </div>
            <div className="col-6">
                <p className="text-white-50">{userEmail}</p>
            </div>
        </div>
    )
}
