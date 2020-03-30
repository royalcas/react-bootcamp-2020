import { suggestedSelector } from 'dashboard/+state/dashboardSelectors';
import React from 'react';
import { connect } from 'react-redux';
import { ActivityList } from './Activities';

export const ActivitySuggestionsConnected = connect(suggestedSelector)(ActivityList);

export const ActivitySuggestions = () => {
  return (
    <div className="suggestion-container">
      <h3>Suggestions</h3>
      <ActivitySuggestionsConnected />
    </div>
  );
};
