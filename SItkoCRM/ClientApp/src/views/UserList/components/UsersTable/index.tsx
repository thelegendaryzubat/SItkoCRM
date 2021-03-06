import React, {Component} from 'react';
import {Link} from 'react-router-dom';

// Externals
import classNames from 'classnames';
import PropTypes from 'prop-types';
import moment from 'moment';
import PerfectScrollbar from 'react-perfect-scrollbar';

// Material helpers
import {withStyles} from '@material-ui/core';

// Material components
import {
    Avatar,
    Checkbox,
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableRow,
    Typography,
    TablePagination
} from '@material-ui/core';

// Shared helpers
import {getInitials} from 'helpers';

// Shared components
import {Portlet, PortletContent} from 'components';

// Component styles
import styles from './styles';
import {Client} from '../../../../components/entities/Client';

interface UsersTableProps {
    users: Client[];
    onSelect(selectedUsers: number[]);
    selectedUsers: number[];
    classes;
    className: string;
    
}

interface UserTableState {
    selectedUsers: number[];
    rowsPerPage: number;
    page: number;
    activeTab: number;
}

class UsersTable extends Component<UsersTableProps> {
    state: UserTableState = {
        selectedUsers: [],
        rowsPerPage: 10,
        page: 0,
        activeTab: 0
    };

    handleSelectAll = event => {
        const {users, onSelect} = this.props;

        let selectedUsers;

        if (event.target.checked) {
            selectedUsers = users.map(user => user.id);
        } else {
            selectedUsers = [];
        }

        this.setState({selectedUsers});

        onSelect(selectedUsers);
    };

    handleSelectOne = (event, id: number) => {
        const {onSelect} = this.props;
        const {selectedUsers} = this.state;

        const selectedIndex: number = selectedUsers.indexOf(id);
        let newSelectedUsers: number[] = [];

        if (selectedIndex === -1) {
            newSelectedUsers = newSelectedUsers.concat(selectedUsers, id);
        } else if (selectedIndex === 0) {
            newSelectedUsers = newSelectedUsers.concat(selectedUsers.slice(1));
        } else if (selectedIndex === selectedUsers.length - 1) {
            newSelectedUsers = newSelectedUsers.concat(selectedUsers.slice(0, -1));
        } else if (selectedIndex > 0) {
            newSelectedUsers = newSelectedUsers.concat(
                selectedUsers.slice(0, selectedIndex),
                selectedUsers.slice(selectedIndex + 1)
            );
        }

        this.setState({selectedUsers: newSelectedUsers});

        onSelect(newSelectedUsers);
    };

    handleChangePage = (event, page) => {
        this.setState({page});
    };

    handleChangeRowsPerPage = event => {
        this.setState({rowsPerPage: event.target.value});
    };

    render() {
        const {classes, className, users} = this.props;
        const {activeTab, selectedUsers, rowsPerPage, page} = this.state;

        const rootClassName = classNames(classes.root, className);

        return (
            <Portlet className={rootClassName}>
                <PortletContent noPadding>
                    <PerfectScrollbar>
                        <Table>
                            <TableHead>
                                <TableRow>
                                    <TableCell align="left">
                                        <Checkbox
                                            checked={selectedUsers.length === users.length}
                                            color="primary"
                                            indeterminate={
                                                selectedUsers.length > 0 &&
                                                selectedUsers.length < users.length
                                            }
                                            onChange={this.handleSelectAll}
                                        />
                                        Name
                                    </TableCell>
                                    <TableCell align="left">ID</TableCell>
                                    {/*<TableCell align="left">State</TableCell>*/}
                                    {/*<TableCell align="left">Phone</TableCell>*/}
                                    {/*<TableCell align="left">Registration date</TableCell>*/}
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {users
                                    .slice(0, rowsPerPage)
                                    .map((user: Client) => (
                                        <TableRow
                                            className={classes.tableRow}
                                            hover
                                            key={user.id}
                                            selected={selectedUsers.indexOf(user.id) !== -1}
                                        >
                                            <TableCell className={classes.tableCell}>
                                                <div className={classes.tableCellInner}>
                                                    <Checkbox
                                                        checked={selectedUsers.indexOf(user.id) !== -1}
                                                        color="primary"
                                                        onChange={event =>
                                                            this.handleSelectOne(event, user.id)
                                                        }
                                                        value="true"
                                                    />
                                                    {/*<Avatar*/}
                                                    {/*    className={classes.avatar}*/}
                                                    {/*    src={user.avatarUrl}*/}
                                                    {/*>*/}
                                                    {/*    {getInitials(user.name)}*/}
                                                    {/*</Avatar>*/}
                                                    <Link to="#">
                                                        <Typography
                                                            className={classes.nameText}
                                                            variant="body1"
                                                        >
                                                            {user.name}
                                                        </Typography>
                                                    </Link>
                                                </div>
                                            </TableCell>
                                            <TableCell className={classes.tableCell}>
                                                {user.id}
                                            </TableCell>
                                            {/*<TableCell className={classes.tableCell}>*/}
                                            {/*    {user.address.state}*/}
                                            {/*</TableCell>*/}
                                            {/*<TableCell className={classes.tableCell}>*/}
                                            {/*    {user.phone}*/}
                                            {/*</TableCell>*/}
                                            {/*<TableCell className={classes.tableCell}>*/}
                                            {/*    {moment(user.createdAt).format('DD/MM/YYYY')}*/}
                                            {/*</TableCell>*/}
                                        </TableRow>
                                    ))}
                            </TableBody>
                        </Table>
                    </PerfectScrollbar>
                    <TablePagination
                        backIconButtonProps={{
                            'aria-label': 'Previous Page'
                        }}
                        component="div"
                        count={users.length}
                        nextIconButtonProps={{
                            'aria-label': 'Next Page'
                        }}
                        onChangePage={this.handleChangePage}
                        onChangeRowsPerPage={this.handleChangeRowsPerPage}
                        page={page}
                        rowsPerPage={rowsPerPage}
                        rowsPerPageOptions={[5, 10, 25]}
                    />
                </PortletContent>
            </Portlet>
        );
    }
}

// @ts-ignore
export default withStyles(styles)(UsersTable);
