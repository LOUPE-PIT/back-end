import React, { FC, useEffect, useState } from 'react';
import { usefeedbackService } from '../../../server/api/feedbackdata/feedbackservice';
import { feedback } from '../../../server/api/feedbackdata/model/feedback';
import Feedbacks from './FeedbacksComponent';

interface FeedbackComponentProps {}

const FeedbackComponent: FC<FeedbackComponentProps> = () => {
  const feedbackService = usefeedbackService();
  const [feedbacks, setFeedbacks] = useState<feedback[]>([]);

  useEffect(() => {
    if (feedbackService !== undefined) {

      const logId = sessionStorage.getItem('logId');
      feedbackService.getfeedbacks(logId).then((result) => {
        setFeedbacks(result);
      });
    }
  }, [feedbackService]);

  return <Feedbacks feedbacks={feedbacks}></Feedbacks>;
};

export default FeedbackComponent;
